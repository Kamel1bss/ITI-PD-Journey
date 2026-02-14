#include <iostream>
using namespace std;

#define SUBJECTS 5

struct Student {
    int ID;
    char Name[30];
    int Grades[SUBJECTS];
};

Student FillStudent();
void PrintStudent(const Student &student);
int SumGrades(const Student &student);

int main() {
    int numberOfStudents = 0;
    cout << "Enter number of students: ";
    cin >> numberOfStudents;

    Student *students = new Student[numberOfStudents];
    for(int i = 0; i < numberOfStudents; i++) {
        students[i] = FillStudent();
    }

    for(int i = 0; i < numberOfStudents; i++) {
        PrintStudent(students[i]);
        int sum = SumGrades(students[i]);
        cout << "Sum of Grades for student " << students[i].ID << " is: " << sum << "\n\n";
    }

    delete[] students;
    return 0;
}

Student FillStudent() {
    Student student;
    cout << "Enter student name: ";
    cin >> student.Name;
    cout << "Enter student ID: ";
    cin >> student.ID;
    for(int i = 0; i < SUBJECTS; i++) {
        cout << "Enter Grade for subject " << i+1 << ": ";
        cin >> student.Grades[i];
    }
    return student;
}

void PrintStudent(const Student &student) {
    cout << "Student Name: " << student.Name << "\n";
    cout << "Student ID: " << student.ID << "\n";
    cout << "Grades for the " << SUBJECTS << " subjects:\n";
    for(int i = 0; i < SUBJECTS; i++) {
        cout << "  Subject " << i+1 << ": " << student.Grades[i] << "\n";
    }
}

int SumGrades(const Student &student) {
    int sum = 0;
    for(int i = 0; i < SUBJECTS; i++) {
        sum += student.Grades[i];
    }
    return sum;
}
