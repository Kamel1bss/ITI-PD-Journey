-- STAGING AREA
CREATE SCHEMA STAGING;

-- DATAWAREHOUSE CORE
CREATE SCHEMA CORE;

-- PREPARE TABLE TO GET DATA FROM SOURCE TO STAGING AREA
CREATE TABLE DATAWAREHOUSEX.STAGING.superstore_raw (
    order_id STRING,
    order_date STRING,
    ship_date STRING,
    ship_mode STRING,
    customer_id STRING,
    customer_name STRING,
    segment STRING,
    country STRING,
    city STRING,
    state STRING,
    postal_code STRING,
    region STRING,
    product_id STRING,
    category STRING,
    sub_category STRING,
    product_name STRING,
    sales STRING,
    quantity STRING,
    discount STRING,
    profit STRING
);
----------------------------------------------------------------------------------------------------------------
--------------------------------------------------------
-- IMPLEMENT THE STAR SCHEMA IN THE CORE DATAWAREHOUSE |
--------------------------------------------------------
CREATE OR REPLACE TABLE DATAWAREHOUSEX.CORE.dim_product (
    product_key INTEGER AUTOINCREMENT PRIMARY KEY,
    product_id STRING,
    product_name STRING,
    category STRING,
    sub_category STRING
);

CREATE OR REPLACE TABLE DATAWAREHOUSEX.CORE.dim_customer (
    customer_key INTEGER AUTOINCREMENT PRIMARY KEY,
    customer_id STRING,
    customer_name STRING,
    segment STRING
);

CREATE OR REPLACE TABLE DATAWAREHOUSEX.CORE.dim_date (
    date_key INTEGER PRIMARY KEY,   -- YYYYMMDD
    full_date DATE,
    year INTEGER,
    quarter INTEGER,
    month INTEGER,
    day INTEGER
);

CREATE OR REPLACE TABLE DATAWAREHOUSEX.CORE.dim_location (
    location_key INTEGER AUTOINCREMENT PRIMARY KEY,
    country STRING,
    city STRING,
    region STRING,
    postal_code INTEGER,
    state STRING
);

CREATE OR REPLACE TABLE DATAWAREHOUSEX.CORE.fact_sales (
    sales_key INTEGER AUTOINCREMENT PRIMARY KEY,

    order_id STRING,  -- degenerate dimension

    product_key INTEGER,
    customer_key INTEGER,
    order_date_key INTEGER,
    ship_date_key INTEGER,
    location_key INTEGER,

    sales NUMBER(18,2),
    quantity INTEGER,
    discount NUMBER(5,2),
    profit NUMBER(18,2),

    FOREIGN KEY (product_key) REFERENCES DATAWAREHOUSEX.CORE.dim_product(product_key),
    FOREIGN KEY (customer_key) REFERENCES DATAWAREHOUSEX.CORE.dim_customer(customer_key),
    FOREIGN KEY (order_date_key) REFERENCES DATAWAREHOUSEX.CORE.dim_date(date_key),
    FOREIGN KEY (ship_date_key) REFERENCES DATAWAREHOUSEX.CORE.dim_date(date_key),
    FOREIGN KEY (location_key) REFERENCES DATAWAREHOUSEX.CORE.dim_location(location_key)
);
----------------------------------------------------------------------------------------------------------------
---------------------------------------------
-- LOADING DATA INTO THE CORE DATAWAREHOUSE |
---------------------------------------------
-- [DIMENSIONS]
INSERT INTO DATAWAREHOUSEX.CORE.dim_product (product_id, product_name, category, sub_category)
SELECT DISTINCT
    product_id,
    product_name,
    category,
    sub_category
FROM DATAWAREHOUSEX.STAGING.SUPERSTORE_RAW;

INSERT INTO DATAWAREHOUSEX.CORE.dim_customer (customer_id, customer_name, segment)
SELECT DISTINCT
    customer_id,
    customer_name,
    segment
FROM DATAWAREHOUSEX.STAGING.SUPERSTORE_RAW;

INSERT INTO DATAWAREHOUSEX.CORE.dim_location (country, city, region, postal_code, state)
SELECT DISTINCT
    country,
    city,
    region,
    TRY_CAST(postal_code AS INTEGER),
    state
FROM DATAWAREHOUSEX.STAGING.SUPERSTORE_RAW;

INSERT INTO DATAWAREHOUSEX.CORE.dim_date (date_key, full_date, year, quarter, month, day)
SELECT DISTINCT
    TO_NUMBER(TO_CHAR(all_dates.dt, 'YYYYMMDD')) AS date_key,
    all_dates.dt AS full_date,
    YEAR(all_dates.dt) AS year,
    QUARTER(all_dates.dt) AS quarter,
    MONTH(all_dates.dt) AS month,
    DAY(all_dates.dt) AS day
FROM (
    SELECT TRY_TO_DATE(order_date, 'MM/DD/YYYY') AS dt FROM DATAWAREHOUSEX.STAGING.SUPERSTORE_RAW
    UNION
    SELECT TRY_TO_DATE(ship_date,  'MM/DD/YYYY') AS dt FROM DATAWAREHOUSEX.STAGING.SUPERSTORE_RAW
) all_dates
WHERE all_dates.dt IS NOT NULL;
----------------------------------------------------------------------------
-- [FACT TABLE]
INSERT INTO DATAWAREHOUSEX.CORE.fact_sales (
    order_id,
    product_key,
    customer_key,
    order_date_key,
    ship_date_key,
    location_key,
    sales,
    quantity,
    discount,
    profit
)
SELECT
    r.order_id,
    p.product_key,
    c.customer_key,
    TO_NUMBER(TO_CHAR(TRY_TO_DATE(r.order_date, 'MM/DD/YYYY'), 'YYYYMMDD')) AS order_date_key,
    TO_NUMBER(TO_CHAR(TRY_TO_DATE(r.ship_date, 'MM/DD/YYYY'), 'YYYYMMDD')) AS ship_date_key,
    l.location_key,
    TRY_CAST(r.sales AS NUMBER(18, 2)),
    TRY_CAST(r.quantity AS integer),
    TRY_CAST(r.discount AS NUMBER(5, 2)),
    TRY_CAST(r.profit AS NUMBER(18, 2))
FROM
    DATAWAREHOUSEX.STAGING.superstore_raw r 
    JOIN DATAWAREHOUSEX.CORE.dim_product P
        ON r.product_id = p.product_id 
        AND r.product_name = p.product_name
    JOIN DATAWAREHOUSEX.CORE.dim_customer c
        ON r.customer_id = c.customer_id
    JOIN DATAWAREHOUSEX.CORE.dim_location l
        ON r.country = l.country 
        AND r.city = l.city 
        AND r.region = l.region 
        AND r.state = l.state
        AND TRY_CAST(r.postal_code AS integer) = l.postal_code
----------------------------------------------------------------------------------------------------------------
