#include <cmath>
#include <cstdio>
#include <string>
#include <cstring>
#include <iostream>

using namespace std;

class Student {
    int age;
    char fname[51];
    char lname[51];
    int standard;
public:
    void setAge(int _age) {
        age = _age;
    }

    int getAge() {
        return age;
    }

    void setFname(char* _fname) {
        strcpy(fname, _fname);
    }

    char* getFname() {
        return fname;
    }

    void setLname(char* _lname) {
        strcpy(lname, _lname);
    }

    char* getLname() {
        return lname;
    }

    void setStandard(int _standard) {
        standard = _standard;
    }

    int getStandard() {
        return standard;
    }

    void to_string() {
        cout << "\n" << age << "," << fname << "," << lname << "," << standard << "\n";
    }
};


int main() {
    Student s;
    int age; cin >> age;
    char fname[51], lname[51];
    cin >> fname >> lname;
    int standard; cin >> standard;

    s.setAge(age);
    s.setFname(fname);
    s.setLname(lname);
    s.setStandard(standard);

    cout << s.getAge() << "\n";
    cout << s.getLname() << ", " << s.getFname() << "\n";
    cout << s.getStandard() << "\n";
    s.to_string();
    return 0;
}
