#include <iostream>
#include <cmath>
using namespace std;

class Point {
	int x, y;
public:
	Point() {
		x = y = 0;
	}

	Point(int m) {
		x = y = m;
	}

	Point(int x, int y) {
		this->x = x;
		this->y = y;
	}

	void setX(int x) {
		this->x = x;
	}

	int getX() { return x; }

	void setY(int y) {
		this->y = y;
	}

	int getY() { return y; }

};

class Rectangle {
	Point p1, p2;
	int length, width;

public:
	Rectangle(int x1, int y1, int x2, int y2) :p1(x1, y1), p2(x2, y2)
	{
		length = abs(x2 - x1);
		width = abs(y2 - y1);
	}

	void setP1(int x, int y) {
		p1.setX(x);
		p1.setY(y);

		length = abs(p2.getX() - x);
		width = abs(p2.getY() - y);
	}

	void setP2(int x, int y) {
		p2.setX(x);
		p2.setY(y);

		length = abs(p1.getX() - x);
		width = abs(p1.getY() - y);
	}

	Point getP1() { return p1; }
	Point getP2() { return p2; }
	int getArea() { return length * width; }

};

// Association

#define PI 3.142857
class Circle {
	Point* p1, * p2;
	double radius;

public:
	Circle() {
		p1 = p2 = NULL;
		radius = 0;
	}

	Circle(Point* p1, Point* p2) {
		this->p1 = p1;
		this->p2 = p2;

		if (p1 != NULL && p2 != NULL) {
			int dx = p2->getX() - p1->getX();
			int dy = p2->getY() - p1->getY();
			radius = sqrt(pow(dx, 2) + pow(dy, 2));
		}
		else
			radius = 0;
	}

	void setP1(Point* p1) {
		this->p1 = p1;
		if (p1 != NULL && p2 != NULL) {
			int x_diff = p2->getX() - p1->getX();
			int y_diff = p2->getY() - p1->getY();
			radius = sqrt(pow(x_diff, 2) + pow(y_diff, 2));
		}
		else
			radius = 0;
	}

	void setP2(Point* p2) {
		this->p2 = p2;
		if (p1 != NULL && p2 != NULL) {
			int x_diff = p2->getX() - p1->getX();
			int y_diff = p2->getY() - p1->getY();
			radius = sqrt(pow(x_diff, 2) + pow(y_diff, 2));
		}
		else
			radius = 0;
	}

	Point* getP1() { return p1; }
	Point* getP2() { return p2; }

	double getRadius() {
		return radius;
	}

	double getArea() {
		return PI * radius * radius;
	}
};

int main()
{
	Rectangle rec(10, 20, 50, 80);
	cout << "Rectangle Area : " << rec.getArea() << "\n";

	Point p1(10, 20), p2(50, 80);
	Circle cir(&p1, &p2);
	cout << "Circle Area : " << cir.getArea();
}