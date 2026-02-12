#include <cmath>
#include <ctime>
#include <cstdio>
#include <climits>
#include <cstring>
#include <cstdlib>
#include <iostream>
using namespace std;

int main() {
    int l, r;
    cin >> l >> r;

    for (int i = l; i <= r; i++) {
        int num = i;
        if (num == 1)
            cout << "one\n";
        else if (num == 2)
            cout << "two\n";
        else if (num == 3)
            cout << "three\n";
        else if (num == 4)
            cout << "four\n";
        else if (num == 5)
            cout << "five\n";
        else if (num == 6)
            cout << "six\n";
        else if (num == 7)
            cout << "seven\n";
        else if (num == 8)
            cout << "eight\n";
        else if (num == 9)
            cout << "nine\n";
        else {
            if (num % 2)
                cout << "odd\n";
            else
                cout << "even\n";
        }
    }

    return 0;
}