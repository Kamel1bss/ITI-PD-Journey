#include <iostream>
using namespace std;

int main() {
    double depthInKilometers;
    cin >> depthInKilometers;

    double temperatureCelsius = 10 * depthInKilometers + 20;
    double temperatureFahrenheit = 1.8 * temperatureCelsius + 32;

    cout << temperatureCelsius << endl;
    cout << temperatureFahrenheit << endl;

    double yardLength, yardWidth;
    double houseLength, houseWidth;

    cin >> yardLength >> yardWidth;
    cin >> houseLength >> houseWidth;

    double yardArea = yardLength * yardWidth;
    double houseArea = houseLength * houseWidth;
    double grassArea = yardArea - houseArea;

    double cuttingTimeInSeconds = grassArea / 2.0;

    cout << cuttingTimeInSeconds << endl;

    return 0;
}
