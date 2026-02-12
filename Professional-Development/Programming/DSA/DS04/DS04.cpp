#include <iostream>
using namespace std;

struct Node {
    int data;
    Node* next;
};

class LinkedList {
private:
    Node* head;

public:
    LinkedList() {
        head = NULL;
    }

    void insert(int value) {
        Node* newNode = new Node();
        newNode->data = value;
        newNode->next = NULL;

        if (head == NULL) {
            head = newNode;
            return;
        }

        Node* temp = head;
        while (temp->next != NULL) {
            temp = temp->next;
        }
        temp->next = newNode;
    }

    bool search(int key) {
        Node* temp = head;
        while (temp != NULL) {
            if (temp->data == key)
                return true;
            temp = temp->next;
        }
        return false;
    }

    void bubbleSort() {
        if (head == NULL) return;

        bool swapped;
        Node* ptr1;
        Node* lptr = NULL;

        do {
            swapped = false;
            ptr1 = head;

            while (ptr1->next != lptr) {
                if (ptr1->data > ptr1->next->data) {
                    swap(ptr1->data, ptr1->next->data);
                    swapped = true;
                }
                ptr1 = ptr1->next;
            }
            lptr = ptr1;
        } while (swapped);
    }

    void display() {
        Node* temp = head;
        while (temp != NULL) {
            cout << temp->data << " ";
            temp = temp->next;
        }

        cout << "\n";
    }
};

int main() {
    LinkedList list;

    list.insert(5);
    list.insert(2);
    list.insert(9);
    list.insert(1);

    cout << "Original List: ";
    list.display();

    list.bubbleSort();
    cout << "Sorted List: ";
    list.display();

    int key = 9;
    if (list.search(key))
        cout << key << " found in the list." << endl;
    else
        cout << key << " not found in the list." << endl;

    return 0;
}
