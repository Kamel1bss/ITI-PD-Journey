#include <cmath>
#include <cstdio>
#include <string>
#include <iostream>

using namespace std;


int main() {
    string a, b;
    cin >> a >> b;

    int n = a.size(), m = b.size();
    cout << n << " " << m << "\n";
    cout << a << b << "\n";

    char first = a[0], second = b[0];
    a[0] = second;
    b[0] = first;

    cout << a << " " << b;

    return 0;
}
