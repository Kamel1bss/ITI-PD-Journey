#include <cmath>
#include <cstdio>
#include <vector>
#include <iostream>
#include <algorithm>
using namespace std;

struct Student {
    int age;
    char fname[51];
    char lname[51];
    int standard;
};

int main() {
    Student s;
    cin >> s.age;
    cin >> s.fname >> s.lname;
    cin >> s.standard;

    cout << s.age << " " << s.fname << " " << s.lname << " " << s.standard;
    return 0;
}
