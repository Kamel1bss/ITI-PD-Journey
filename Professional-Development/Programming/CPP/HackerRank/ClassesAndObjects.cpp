#include <cmath>
#include <cstdio>
#include <iostream>
using namespace std;

class Student {
    float scores[5];

public:
    void input() {
        float _scores[5];
        for (int i = 0; i < 5; i++)
            cin >> _scores[i];

        for (int i = 0; i < 5; i++)
            scores[i] = _scores[i];
    }

    int calculateTotalScore() {
        int sum = 0;
        for (int i = 0; i < 5; i++) {
            sum += scores[i];
        }

        return sum;
    }
};

int main() {
    int N;
    cin >> N;

    Student* Students = new Student[N];
    for (int i = 0; i < N; i++) {
        Students[i].input();
    }

    int score = Students[0].calculateTotalScore();
    int* scores = new int[N];
    for (int i = 1; i < N; i++)
        scores[i] = Students[i].calculateTotalScore();

    int cnt = 0;
    for (int i = 1; i < N; i++) {
        if (scores[i] > score)
            cnt++;
    }

    cout << cnt;
    return 0;
}
