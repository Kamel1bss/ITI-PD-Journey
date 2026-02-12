#include <iostream>
#include <cstring>
using namespace std;

struct Student {
    char name[50]; 
    int id;
};



struct Node {
    Student data;
    Node* next;
    Node* prev;
};

class StudentList {
private:
    Node* head;
    Node* tail;

public:
    StudentList() {
        head = tail = nullptr;
    }
    void addStudent(const char* name, int id) {
        Node* newNode = new Node;
        strcpy_s(newNode->data.name, name);
        newNode->data.id = id;
        newNode->next = nullptr;
        newNode->prev = nullptr;

        if (head == nullptr) {
            head = tail = newNode;
            return;
        }

        tail->next = newNode;
        newNode->prev = tail;
        tail = newNode;
    }

    void insertAt(int position, const char* name, int id) {
        Node* newNode = new Node;
        strcpy_s(newNode->data.name, name);
        newNode->data.id = id;

        if (position == 0) {
            newNode->next = head;
            newNode->prev = nullptr;

            if (head != nullptr)
                head->prev = newNode;
            else
                tail = newNode;

            head = newNode;
            return;
        }

        Node* temp = head;
        for (int i = 0; i < position - 1 && temp != nullptr; i++)
            temp = temp->next;

        if (temp == nullptr) {
            cout << "Invalid position\n";
            delete newNode;
            return;

            // or
            //tail->next = newNode;
            //newNode->next = nullptr;
            //newNode->prev = tail;
            //tail = newNode;
            
        }

        newNode->next = temp->next;
        newNode->prev = temp;

        if (temp->next != nullptr)
            temp->next->prev = newNode;
        else
            tail = newNode;

        temp->next = newNode;
    }

    void searchById(int id) {
        Node* temp = head;

        while (temp != nullptr) {
            if (temp->data.id == id) {
                cout << "Student Found\n";
                cout << "Name: " << temp->data.name << endl;
                cout << "ID: " << temp->data.id << endl;
                return;
            }
            temp = temp->next;
        }

        cout << "Student not found\n";
    }

    void displayForward() {
        Node* temp = head;
        while (temp != nullptr) {
            cout << temp->data.name << " (" << temp->data.id << "), ";
            temp = temp->next;
        }
    }

    void displayBackward() {
        Node* temp = tail;
        while (temp != nullptr) {
            cout << temp->data.name << " (" << temp->data.id << "), ";
            temp = temp->prev;
        }
    }
};

int main() {
    StudentList list;

    list.addStudent("Ahmed", 101);
    list.addStudent("Kamel", 102);
    list.addStudent("Farouk", 103);

    cout << "Forward:\n";
    list.displayForward();
    cout << "\n=========================================\n";

    cout << "\nInsert at position 1:\n";
    list.insertAt(1, "Mai", 104);
    list.displayForward();
    cout << "\n=========================================\n";

    cout << "\nBackward:\n";
    list.displayBackward();
    cout << "\n=========================================\n";

    cout << "\nSearch by ID 102:\n";
    list.searchById(102);
    cout << "\n=========================================\n";

    return 0;
}
