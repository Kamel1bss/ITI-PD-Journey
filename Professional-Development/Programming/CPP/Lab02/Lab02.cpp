#include <iostream>
#include <cmath>
using namespace std;

// Problem 1: Speed check
void problem1_speeding() {
    int speed;
    cin >> speed;
    if (speed > 65) cout << "SPEEDING" << endl;
}

// Problem 2: Richter scale
void problem2_earthquake() {
    double Richter;
    cin >> Richter;
    if (Richter < 5 && Richter >= 0) cout << "Little or no damage" << endl;
    else if (Richter >= 5 && Richter < 5.5) cout << "Some damage" << endl;
    else if (Richter >= 5.5 && Richter < 6.5) cout << "Serious damage: walls may crack or fall" << endl;
    else if (Richter >= 6.5 && Richter < 7.5) cout << "Disaster: most buildings destroyed" << endl;
    else cout << "Catastrophe: most buildings destroyed" << endl;
}

// Problem 3: Quadrant check
void problem3_quadrant() {
    double x, y;
    cin >> x >> y;
    if (x == 0) cout << "On the y-axis" << endl;
    else if (y == 0) cout << "On the x-axis" << endl;
    else if (x > 0) cout << (y > 0 ? "Quadrant 1" : "Quadrant 4") << endl;
    else cout << (y > 0 ? "Quadrant 2" : "Quadrant 3") << endl;
}

// Problem 4: Cylinder color
void problem4_cylinder() {
    char color;
    cin >> color;
    color = tolower(color);
    switch(color){
        case 'y': cout << "Hydrogen" << endl; break;
        case 'o': cout << "Ammonia" << endl; break;
        case 'b': cout << "Carbon monoxide" << endl; break;
        case 'g': cout << "Oxygen" << endl; break;
        default: cout << "Invalid color" << endl;
    }
}

// Problem 5: Quadratic equation roots
void problem5_quadratic() {
    double a, b, c;
    cin >> a >> b >> c;
    double discriminant = b*b - 4*a*c;
    if(discriminant < 0) cout << "No real roots" << endl;
    else if(discriminant == 0) cout << "One root: " << -b/(2*a) << endl;
    else {
        double x1 = (-b + sqrt(discriminant))/(2*a);
        double x2 = (-b - sqrt(discriminant))/(2*a);
        cout << "Roots: " << x1 << " and " << x2 << endl;
    }
}

// Problem 6: Magic box
 void gotoxy(int x, int y) {
     COORD coord;
     coord.X = x * 4 - 1;  // Multiply by 4 to space numbers
     coord.Y = y - 1;
     SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE), coord);
 }

 void problem6_magicbox() {
     int size = 0, row = 0, col = 0;

     while(size%2 == 0 || size <= 0){
         cout << "Enter the size of the magic box (odd number): ";
         cin >> size;
     }
    
     for(int i = 1; i <= size*size; i++){
         if(i == 1){
             row = 1;
             col = (size+1)/2;
             // gotoxy(col, row);
             cout << i << "==> (" << row << "," << col << ")" << endl;
         }
         else{
             if((i-1)%size == 0){
                 row++;
                 if(row > size){row = 1;}
                 // gotoxy(col, row);
                 cout << i << "==> (" << row << "," << col << ")" << endl;
             }
             else{
                 row--;
                 col--;
                 if(row < 1){row = 1;}
                 if(col < 1){col = 1;}
                 // gotoxy(col, row);
                 cout << i << "==> (" << row << "," << col << ")" << endl;
             }
         }
     }
     cin >> row;// To keep the console window open
     return 0;
 }

// Problem 7: Pi approximation
void problem7_pi_approx() {
    int terms;
    cin >> terms;
    double approximation=0.0;
    int denominator=1, sign=1;
    for(int i=0;i<terms;i++){
        approximation += sign*(4.0/denominator);
        denominator += 2;
        sign=-sign;
    }
    cout.precision(10);
    cout << fixed << approximation << endl;
}

// Problem 8: Min and max of 5 numbers
void problem8_minmax() {
    int number, minNumber, maxNumber;
    cin >> number;
    minNumber = maxNumber = number;
    for(int i=2;i<=5;i++){
        cin >> number;
        if(number < minNumber) minNumber = number;
        if(number > maxNumber) maxNumber = number;
    }
    cout << minNumber << endl;
    cout << maxNumber << endl;
}

int main() {
    // Call the problem you want:
    // problem1_speeding();
    // problem2_earthquake();
    // problem3_quadrant();
    // problem4_cylinder();
    // problem5_quadratic();
    // problem6_magicbox();
    // problem7_pi_approx();
    problem8_minmax();
    return 0;
}
