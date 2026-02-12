#include <iostream>
using namespace std;

class Person {
    int id;
    char name[50];

public:

    Person() {
        id = -1;
        strcpy_s(name,10,"Person");
    }

    Person(int _id, char _name[50]) {
        id = _id;
        strcpy_s(name, 50, _name);
    }

    int getId() {
        return id;
    }

    void setId(int _id) {
        id = _id;
    }

    char* getName() {
        return name;
    }

    void print() {
        cout << "Id : " << id << "\nName : " << name << "\n";
    }
};

class Employee : Person {
    double salary;

public:
    Employee() {
        salary = 0.0;
    }

    Employee(int _id, char _name[50], double _salary) : Person(_id, _name) {
        salary = _salary;
    }

    double getSalary() {
        return salary;
    }

    void setSalary(double _salary) {
        salary = _salary;
    }

    void print() {
        cout << "Id : " << getId() << "\nName : " << getName() << "\nSalary : " << salary;
    }
};

class Customer : Person {
    int productNumber;
public:
    Customer() {
        productNumber = -1;
    }

    Customer(int _id, char _name[50], int _productNumber) : Person(_id, _name) {
        productNumber = _productNumber;
    }

    int getProductNumber() {
        return productNumber;
    }

    void setProductNumber(int _productNumber) {
        productNumber = _productNumber;
    }

    void print() {
        cout << "Id : " << getId() << "\nName : " << getName() << "\nProductNum : " << productNumber;
    }
};

int main()
{
    char name[50] = "Kamel";
    Customer c;
    c.print();

}
