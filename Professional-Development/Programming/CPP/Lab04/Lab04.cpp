#include <iostream>
#include <iomanip>
#include <ctype.h>
#include <cstring>
#include <conio.h>
#include <windows.h>

using namespace std;

/* Problem 1: Sales summary */
void Problem1_SalesSummary(){
    float sales[5][4] = {0};
    float salesperson[4] = {0}, products[5] = {0};
    float sum = 0, total_sales = 0;
    for(int i = 0; i < 5; i++){
        for(int j = 0; j < 4; j++){
            cout << "Enter sales amount for Product " << (i+1) << " by Salesperson " << (j+1) << ": ";
            cin >> sales[i][j];
            sum += sales[i][j];
            total_sales += sales[i][j];
        }
        products[i] = sum;
        sum = 0;
    }

    for(int j = 0; j < 4; j++){
        for(int i = 0; i < 5; i++) sum += sales[i][j];
        salesperson[j] = sum;
        sum = 0;
    }

    cout << left << setw(10) << "Product/Salesperson"
         << right << setw(5) << "SP1" << right << setw(15) << "SP2"
         << right << setw(15) << "SP3" << right << setw(15) << "SP4"
         << right << setw(15) << "Total Product" << '\n';
    cout << setfill('-') << setw(80) << "" << setfill(' ') << '\n';
    for(int i = 0; i <= 5; i++){
        if(i == 5) cout << left << setw(10) << "Salesperson Total";
        else cout << left << setw(10) << "Product " + to_string(i+1);
        for(int j = 0; j < 4; j++){
            if(i == 5) cout << right << setw(15) << fixed << setprecision(2) << salesperson[j];
            else cout << right << setw(15) << fixed << setprecision(2) << sales[i][j];
        }
        if(i == 5) cout << right << setw(15) << fixed << setprecision(2) << total_sales << '\n';
        else cout << right << setw(15) << fixed << setprecision(2) << products[i] << '\n';
    }
}

/* Problem 2: Turtle drawing */
#define COMMANDS 50
void Print2DArray(char board[50][50], int row, int col){
    for(int i=0;i<row;i++){
        for(int j=0;j<col;j++) cout << board[i][j];
        cout << endl;
    }
}
void Problem2_TurtleDrawing(){
    char board[50][50];
    char commands[COMMANDS] = {0};
    cout << "Enter the steps until 20 steps (spaces allowed): \n";
    cin.ignore();
    cin.getline(commands, COMMANDS);

    int x=0,y=0,direction=0,write=0,max_x_drawn=0,max_y_drawn=0,steps=0;
    for(int i=0;i<50;i++) for(int j=0;j<50;j++) board[i][j]=' ';

    for(int i=0; i<COMMANDS && commands[i]!='\0'; i++){
        if(commands[i]==' ') continue;
        else if(commands[i]=='5'){
            i+=2;
            if(isdigit(commands[i+1])) { steps=(commands[i]-'0')*10+(commands[i+1]-'0'); i++; }
            else steps=commands[i]-'0';
            for(int j=0;j<steps;j++){
                if(write==1){ board[y][x]='*'; if(x>max_x_drawn) max_x_drawn=x; if(y>max_y_drawn) max_y_drawn=y; }
                if(j<steps-1){
                    switch(direction){
                        case 0: if(x<49) x++; break;
                        case 1: if(y<49) y++; break;
                        case 2: if(x>0) x--; break;
                        case 3: if(y>0) y--; break;
                    }
                }
            }
        }
        else if(commands[i]=='1') write=0;
        else if(commands[i]=='2') write=1;
        else if(commands[i]=='3') direction=(direction+1)%4;
        else if(commands[i]=='6'){ Print2DArray(board,max_y_drawn+1,max_x_drawn+1); break;}
    }
}

/* Problem 3: Student marks */
void Problem3_StudentMarks(){
    int students[3][4], sum_student[3], sum_subject[4];
    float avg_subject[4];
    int temp=0;
    for(int i=0;i<3;i++){
        cout << "Enter marks for Student " << (i+1) << "\n";
        for(int j=0;j<4;j++){ cin >> students[i][j]; temp+=students[i][j];}
        sum_student[i]=temp; temp=0;
    }
    for(int j=0;j<4;j++){ for(int i=0;i<3;i++) temp+=students[i][j]; sum_subject[j]=temp; avg_subject[j]=(float)temp/3; temp=0;}
    int max_student=sum_student[0];
    for(int i=0;i<3;i++){ cout << "Total marks for Student " << (i+1) << ": " << sum_student[i] << "\n"; if(sum_student[i]>max_student) max_student=sum_student[i];}
    for(int j=0;j<4;j++) cout << "Average marks for Subject " << (j+1) << ": " << avg_subject[j] << "\n";
    cout << "Highest marks obtained by a student: " << max_student << "\n";
}

/* Problem 4: Alternate capitalization */
void Problem4_AlternateCaps(){
    char arr[100];
    cout << "Enter a string: ";
    cin.ignore();
    cin.getline(arr,100);
    int flag=1;
    for(int i=0;arr[i]!='\0';i++){
        if(flag){ cout << (char)toupper(arr[i]); flag=0; }
        else{ cout << (char)tolower(arr[i]); flag=1; }
    }
    cout << endl;
}

/* Problem 5: Sum and average of digits */
void Problem5_SumAvgDigits(){
    char number[10];
    cout << "Enter a number: ";
    cin.ignore();
    cin.getline(number,10);
    int sum=0;
    for(int i=0;number[i]!='\0';i++) if(number[i]>='0' && number[i]<='9') sum+=number[i]-'0';
    cout << "Sum of digits in your number is: " << sum << "\n";
    cout << "Average of digits in your number is: " << fixed << setprecision(2) << sum/(float)strlen(number) << "\n";
}

/* Problem 6: Line Editor */
void gotoxy(int x,int y){ COORD coord={}; coord.X=x; coord.Y=y; SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE),coord);}
#define START_Y 4
void Problem6_LineEditor(){
    int size=0;
    cout << "Enter the size of the line: "; cin >> size;
    char *line=new char[size]; for(int i=0;i<size;i++) line[i]='\0';
    cin.ignore();
    int x=0; char temp; int terminate=0;
    cout << "Enter the line: "; gotoxy(x,START_Y);
    while(!terminate){
        temp=getch();
        if(temp==27){ system("cls"); terminate=1; }
        else if(temp=='\0'){ temp=getch(); if(temp==75 && x>0) gotoxy(--x,START_Y); else if(temp==77 && x<size-1) gotoxy(++x,START_Y); else if(temp==71) {x=0; gotoxy(x,START_Y);} else if(temp==79) {for(int i=x;i<size-1;i++) line[i]=' '; x=size-1; gotoxy(x,START_Y);} }
        else if(temp==8){ if(x>0){ x--; gotoxy(x,START_Y); cout << ' '; line[x]='\0'; gotoxy(x,START_Y);} }
        else if(temp>=32 && temp<=126){ if(x<size-1){ gotoxy(x,START_Y); cout<<temp; line[x]=temp; x++;} }
        else if(temp==13){ terminate=1; system("cls"); cout<<line<<endl;}
    }
    delete[] line;
}

int main(){
    // Call any Lab04 problem function here
    //Problem1_SalesSummary();
    //Problem2_TurtleDrawing();
    //Problem3_StudentMarks();
    //Problem4_AlternateCaps();
    //Problem5_SumAvgDigits();
    //Problem6_LineEditor();
    return 0;
}
