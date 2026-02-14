#include <iostream>
#include <cstring>

using namespace std;

#define SUBJECTS 5
class Student{
    int ID;
    char Name[30];
    int NumGrades;
    float *Grades;
public:
    Student();
    ~Student();
    Student(Student &student);
    void SetID(int ID){this->ID = ID;}
    void SetName(char Name[30]){strcpy(this->Name, Name);}
    void SetNumGrades(int NumGrades){
        this->NumGrades = NumGrades;
        delete[] Grades;
        Grades = new float[NumGrades];
    }
    void SetGrades(int *Grades){
        for(int i = 0; i < this->NumGrades; i++){
            this->Grades[i] = Grades[i];
        }
    }
    int GetID(){return ID;}
    char* GetName(){return Name;}
    int GetNumGrades(){return NumGrades;}
    float* GetGrades(){return Grades;}
};

Student FillStudent();
void PrintStudent(Student &student);
int SumGrades(Student &student);

int main(){
    int number = 0;
    cout << "Enter number of students: ";
    cin >> number;
    Student *arr = new Student[number];
    for(int i = 0; i < number; i++){
        arr[i] = FillStudent();
    }
    for(int i = 0; i < number; i++){
        PrintStudent(arr[i]);
        int sum = SumGrades(arr[i]);
        cout << "Sum of Grades for student " << arr[i].GetID() << " is: " << sum << endl;
    }
    delete[] arr;
    return 0;
}

Student::Student(){
    ID = 0;
    Name[0] = '\0';
    NumGrades = 0;
    Grades = new float[NumGrades];
}

Student::~Student(){
    delete[] Grades;
}

Student::Student(Student &student){
    ID = student.ID;
    strcpy(Name, student.Name);
    NumGrades = student.NumGrades;
    Grades = new float[NumGrades];
    for(int i = 0; i < NumGrades; i++){
        Grades[i] = student.Grades[i];
    }
}

Student FillStudent(){
    Student student;
    cout << "Enter student name: ";
    char name[30];
    cin >> name;
    student.SetName(name);
    cout << "Enter student ID: ";
    int ID; cin >> ID;
    student.SetID(ID);
    cout << "Enter number of grades: ";
    int NumGrades; cin >> NumGrades;
    student.SetNumGrades(NumGrades);
    float *grades = student.GetGrades();
    for(int i = 0; i < NumGrades; i++){
        cout << "Enter Grade for subject " << i+1 << ": ";
        cin >> grades[i];
    }
    return student;
}

void PrintStudent(Student &student){
    cout << "Student Name is: " << student.GetName() << endl;
    cout << "Student ID is: " << student.GetID() << endl;
    int NumGrades = student.GetNumGrades();
    cout << "Grades for the " << NumGrades << " subjects" << endl;
    float *grades = student.GetGrades();
    for(int i = 0; i < NumGrades; i++){
        cout << "Subject " << i+1 << ": " << grades[i] << endl;
    }
}

int SumGrades(Student &student){
    int sum = 0;
    int NumGrades = student.GetNumGrades();
    float *grades = student.GetGrades();
    for(int i = 0; i < NumGrades; i++){
        sum += grades[i];
    }
    return sum;
}