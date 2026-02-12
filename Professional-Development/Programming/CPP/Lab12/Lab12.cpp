#include <iostream>
#include <fstream>
#include <string>
using namespace std;

int main()
{
	cout << "===========================\n";
	cout << "         TXT File          \n";
	cout << "===========================\n";

	// Write to file
	fstream obj;
	obj.open("text.txt", ios::out);
	obj << "Ahmed Kamel Farouk Ayad";
	obj.close();

	// Read from file
	obj.open("text.txt", ios::in);
	char print[100];

	// obj >> print;
	obj.getline(print, 100);
	cout << print;
}
