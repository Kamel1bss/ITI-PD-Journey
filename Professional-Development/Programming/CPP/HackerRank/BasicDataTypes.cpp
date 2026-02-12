#include <cmath>
#include <cstdio>
#include <vector>
#include <iostream>
#include <algorithm>
#include <iomanip>
using namespace std;


int main() {
	/* Enter your code here. Read input from STDIN. Print output to STDOUT */  
	int a; long b; char c; float f; double d;
	cin >> a >> b >> c >> f >> d;
	cout << a << "\n";
	cout << b << "\n";
	cout << c << "\n";
	cout << fixed;
	cout << setprecision(3) << f << "\n";
	cout << setprecision(9) << d << "\n";
	return 0;
}
