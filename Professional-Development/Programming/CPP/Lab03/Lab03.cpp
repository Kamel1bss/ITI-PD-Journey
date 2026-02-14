#include <iostream>
#include <cmath>
#include <iomanip>
#include <climits>
using namespace std;

// Problem 1: Car Rental Charges
void problem1_carRental() {
    int hours[3];
    for(int i = 0; i < 3; i++) cin >> hours[i];

    int charges[3];
    const int FEE_PER_8HOURS = 25;
    const int FEE_PER_HOUR = 5;
    const int CHARGE_PER_DAY = 50;
    const double TAX_PER_HOUR = 0.5;

    for(int i = 0; i < 3; i++){
        if(hours[i] >= 24){
            charges[i] = (hours[i]/24)*CHARGE_PER_DAY + (hours[i]%24)*FEE_PER_HOUR + hours[i]*TAX_PER_HOUR;
        } else {
            charges[i] = FEE_PER_8HOURS + (hours[i]-8)*FEE_PER_HOUR + hours[i]*TAX_PER_HOUR;
        }
    }

    cout << left << setw(10) << "Car" << right << setw(15) << "Hours" << right << setw(15) << "Charge" << endl;
    cout << setfill('-') << setw(40) << "" << setfill(' ') << endl;
    for(int i = 0; i < 3; i++){
        cout << left << setw(10) << i+1 << right << setw(15) << hours[i] << right << setw(15) << charges[i] << endl;
    }
}

// Problem 2: Hypotenuse
double hypotenuse(double a, double b){
    return sqrt(a*a + b*b);
}

// Problem 3: Triangle Area
double triangleArea(double a, double b, double c){
    if(a+b>c && a+c>b && b+c>a){
        double s = (a+b+c)/2;
        return sqrt(s*(s-a)*(s-b)*(s-c));
    }
    return -1;
}

// Problem 4: Check Right Triangle
int isRightTriangle(int a, int b, int c){
    if(a*a+b*b==c*c || a*a+c*c==b*b || b*b+c*c==a*a) return 1;
    else if(a+b>c && a+c>b && b+c>a) return 0;
    else return -1;
}

// Problem 5: Currency Conversion
double toYen(double usd){ return usd*118.87; }
double toEuro(double usd){ return usd*0.92; }

// Problem 6: Sum of digits
int sumDigits(int num){
    num = abs(num);
    int sum = 0;
    while(num>0){ sum += num%10; num/=10; }
    return sum;
}

// Problem 7: Power (recursive)
long power(int base, int exp){
    if(exp==1) return base;
    return base*power(base, exp-1);
}

// Problem 8: Fibonacci
unsigned long long fibonacci(unsigned int n){
    if(n==1) return 0;
    if(n==2) return 1;
    unsigned long long a=0, b=1, c;
    for(int i=3;i<=n;i++){
        c=a+b; a=b; b=c;
    }
    return b;
}

// Problem 9: Salesperson salary ranges
void problem9_sales(){
    const int RANGE_COUNT=9;
    const int BASE=200;
    const double COMM=0.09;
    int n;
    cin >> n;
    int ranges[RANGE_COUNT]={0};
    for(int i=0;i<n;i++){
        int sales; cin>>sales;
        int total=(int)(BASE + sales*COMM);
        if(total<300) ranges[0]++;
        else if(total<400) ranges[1]++;
        else if(total<500) ranges[2]++;
        else if(total<600) ranges[3]++;
        else if(total<700) ranges[4]++;
        else if(total<800) ranges[5]++;
        else if(total<900) ranges[6]++;
        else if(total<1000) ranges[7]++;
        else ranges[8]++;
    }
    for(int i=0;i<RANGE_COUNT;i++){
        if(i==RANGE_COUNT-1) cout<<"$1000 and over: "<<ranges[i]<<endl;
        else cout<<"$"<<(i+2)*100<<"-$"<<(i+3)*100<<": "<<ranges[i]<<endl;
    }
}

// Problem 10: Array operations
void problem10_arrays(){
    double sales[20]; for(int i=0;i<20;i++) cin>>sales[i];
    double allowance[75]={0}; for(int i=0;i<75;i++) allowance[i]+=1000;
    int numbers[50]={0};
    float GPA[10]={3.5,3.7,3.2,3.8,3.0,3.9,2.8,3.6,3.4,3.1};
    for(int i=0;i<10;i++) cout<<"GPA["<<i<<"]="<<GPA[i]<<endl;
}

// Problem 11: Unique elements common in two sets
void problem11_unique(){
    int set1[10], set2[10];
    for(int i=0;i<10;i++) cin>>set1[i];
    for(int i=0;i<10;i++) cin>>set2[i];
    for(int i=0;i<10;i++){
        bool unique1=true, unique2=true;
        for(int j=0;j<10;j++){
            if(set1[i]==set2[j]) unique1=false;
            if(set2[i]==set1[j]) unique2=false;
        }
        if(unique1) cout<<set1[i]<<" ";
        if(unique2) cout<<set2[i]<<" ";
    }
    cout<<endl;
}

int main(){
    // Call any problem function you want, e.g.
    // problem1_carRental();
    // cout<<hypotenuse(3,4)<<endl;
    // cout<<triangleArea(3,4,5)<<endl;
    // cout<<isRightTriangle(3,4,5)<<endl;
    // cout<<toYen(10)<<" "<<toEuro(10)<<endl;
    // cout<<sumDigits(7631)<<endl;
    // cout<<power(3,4)<<endl;
    // cout<<fibonacci(10)<<endl;
    // problem9_sales();
    // problem10_arrays();
    problem11_unique();
    return 0;
}
