#include <iostream>
#include <cstring>

using namespace std;

#define SUBJECTS 3

class Student {
    int ID;
    char* Name;
    float Grades[SUBJECTS];

public:
    Student();
    Student(int id, const char* name, float grades[SUBJECTS]);
    Student(const Student& student);
    ~Student();

    void SetID(int ID) { this->ID = ID; }
    void SetName(const char* name);
    void SetGrades(float grades[SUBJECTS]);

    int GetID() const { return ID; }
    const char* GetName() const { return Name; }
    float* GetGrades() { return Grades; }

    Student operator + (int num) const;
    Student operator + (const char* name) const;
    Student operator + (const Student& student) const;
    Student operator ++ ();
    Student operator ++ (int);
    operator int() const;
    operator char*() const;
    Student& operator = (const Student& student);
    bool operator == (const Student& student) const;
};

Student operator + (int num, const Student& student);
Student operator + (const char* name, const Student& student);
Student FillStudent();
void PrintStudent(const Student& student);
int SumGrades(const Student& student);

int main() {
    int number = 0;
    cout << "Enter number of students: ";
    cin >> number;
    Student* arr = new Student[number];
    cin.ignore();

    for(int i = 0; i < number; i++)
        arr[i] = FillStudent();

    for(int i = 0; i < number; i++) {
        PrintStudent(arr[i]);
        int sum = SumGrades(arr[i]);
        cout << "Sum of Grades for student " << arr[i].GetID() << " is: " << sum << endl << endl;
    }

    arr[0]++;
    cout << "After post-increment of first student:" << endl;
    PrintStudent(arr[0]);

    delete[] arr;
    return 0;
}

Student::Student() {
    ID = 0;
    Name = new char[40];
    Name[0] = '\0';
    for(int i = 0; i < SUBJECTS; i++)
        Grades[i] = 0;
}

Student::Student(int id, const char* name, float grades[SUBJECTS]) {
    ID = id;
    Name = new char[strlen(name) + 1];
    strcpy(Name, name);
    for(int i = 0; i < SUBJECTS; i++)
        Grades[i] = grades[i];
}

Student::Student(const Student& student) {
    ID = student.ID;
    Name = new char[strlen(student.Name) + 1];
    strcpy(Name, student.Name);
    for(int i = 0; i < SUBJECTS; i++)
        Grades[i] = student.Grades[i];
}

Student::~Student() {
    delete[] Name;
}

void Student::SetName(const char* name) {
    delete[] Name;
    Name = new char[strlen(name) + 1];
    strcpy(Name, name);
}

void Student::SetGrades(float grades[SUBJECTS]) {
    for(int i = 0; i < SUBJECTS; i++)
        Grades[i] = grades[i];
}

Student Student::operator + (int num) const {
    return Student(ID + num, Name, Grades);
}

Student Student::operator + (const char* name) const {
    char newName[strlen(Name) + strlen(name) + 1];
    strcpy(newName, Name);
    strcat(newName, name);
    return Student(ID, newName, Grades);
}

Student Student::operator + (const Student& student) const {
    char newName[strlen(Name) + strlen(student.Name) + 1];
    strcpy(newName, Name);
    strcat(newName, student.Name);
    float newGrades[SUBJECTS];
    for(int i = 0; i < SUBJECTS; i++)
        newGrades[i] = Grades[i] + student.Grades[i];
    return Student(ID + student.ID, newName, newGrades);
}

Student Student::operator ++ () {
    ID++;
    return *this;
}

Student Student::operator ++ (int) {
    Student temp(*this);
    ID++;
    return temp;
}

Student::operator int() const {
    return ID;
}

Student::operator char*() const {
    return Name;
}

Student& Student::operator = (const Student& student) {
    if(this != &student) {
        ID = student.ID;
        delete[] Name;
        Name = new char[strlen(student.Name) + 1];
        strcpy(Name, student.Name);
        for(int i = 0; i < SUBJECTS; i++)
            Grades[i] = student.Grades[i];
    }
    return *this;
}

bool Student::operator == (const Student& student) const {
    if(ID != student.ID) return false;
    if(strcmp(Name, student.Name) != 0) return false;
    for(int i = 0; i < SUBJECTS; i++)
        if(Grades[i] != student.Grades[i])
            return false;
    return true;
}

Student operator + (int num, const Student& student) {
    return Student(num + student.GetID(), student.GetName(), student.GetGrades());
}

Student operator + (const char* name, const Student& student) {
    char newName[strlen(name) + strlen(student.GetName()) + 1];
    strcpy(newName, name);
    strcat(newName, student.GetName());
    return Student(student.GetID(), newName, student.GetGrades());
}

Student FillStudent() {
    Student student;
    cout << "Enter student name: ";
    char name[30];
    cin >> name;
    student.SetName(name);
    cout << "Enter student ID: ";
    int ID; cin >> ID;
    student.SetID(ID);
    float* grades = student.GetGrades();
    for(int i = 0; i < SUBJECTS; i++) {
        cout << "Enter Grade for subject " << i+1 << ": ";
        cin >> grades[i];
    }
    return student;
}

void PrintStudent(const Student& student) {
    cout << "Student Name is: " << student.GetName() << endl;
    cout << "Student ID is: " << student.GetID() << endl;
    cout << "Grades for the " << SUBJECTS << " subjects:" << endl;
    float* grades = student.GetGrades();
    for(int i = 0; i < SUBJECTS; i++)
        cout << "Subject " << i+1 << ": " << grades[i] << endl;
}

int SumGrades(const Student& student) {
    int sum = 0;
    float* grades = student.GetGrades();
    for(int i = 0; i < SUBJECTS; i++)
        sum += grades[i];
    return sum;
}
