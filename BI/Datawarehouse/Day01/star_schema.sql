create table dim_product (
	product_key int primary key identity,
	product_id varchar(255),
	product_name varchar(255),
	category varchar(255),
	sub_category varchar(255)
);

create table dim_customer (
	customer_key int primary key identity,
	customer_id varchar(255),
	customer_name varchar(255),
	segment varchar(255)
);

create table dim_date (
	date_key int primary key,
	full_date date,
	year int,
	quarter int,
	month int,
	day int
);

create table dim_location (
	location_key int primary key identity,
	country varchar(255),
	city varchar(255),
	region varchar(255),
	postal_code int,
	state varchar(255)
);

create table fact_sales (
	sales_key int identity primary key,  

	order_id varchar(255), -- degenerate dimension

	product_key int,
	customer_key int,
	order_date_key int,    -- role-playing dimension
	ship_date_key int,     -- role-playing dimension
	location_key int,

	sales decimal(18, 2),
	quantity int,
	discount decimal(5, 2),
	profit decimal(18, 2),

	foreign key (product_key) references dim_product(product_key),
	foreign key (customer_key) references dim_customer(customer_key),
	foreign key (order_date_key) references dim_date(date_key),
	foreign key (ship_date_key) references dim_date(date_key),
	foreign key (location_key) references dim_location(location_key)
);
