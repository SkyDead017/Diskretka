#pragma once
#include"Class.h"
#include"Methods.h"
using namespace std;
bool isCorrectInput() {
	if (cin.fail() || cin.peek() != '\n') {
		cin.clear();
		cin.seekg(cin.eof());
		cout << "������ �����! " << "������� ����� �����" << endl;
		return false;
	}
	return true;
}

int choiceSet() {
	cout << "1. ������� ��������� �" << endl;
	cout << "2. ������� ��������� B" << endl;
	cout << "3. ������� ��������� C" << endl;
	cout << "4. ������� ��������� D" << endl;
	cout << "5. ������� ��������� E" << endl;
	int choiceSet;
	do {
		cin >> choiceSet;
		if (isCorrectInput()) {
			if (choiceSet < 1 || choiceSet > 6) {
				cout << "������� ���������� ��������!" << endl;
			}
		}
	} while ((choiceSet < 1 || choiceSet > 6) || !isCorrectInput());
	return choiceSet;
}


void CreateSets(vector<Set>& sets, Set U, vector<char> setsNames)
{
	int choiceHowCreate;
	for (int i = 0; i < 5; ++i)
	{
		system("cls");
		cout << "1. ������ ��������� " << setsNames[i] << endl;
		cout << "2. �������� ��� ��������� ������" << endl;
		do {
			cin >> choiceHowCreate;
			if (isCorrectInput()) {
				if (choiceHowCreate != 1 && choiceHowCreate != 2) {
					cout << "������� ���������� ��������!" << endl;
				}
			}
		} while ((choiceHowCreate != 1 && choiceHowCreate != 2) || !isCorrectInput());
		int setSize;
		if (choiceHowCreate == 1) {
			system("cls");
			cout << "1. ������ ��������� " << setsNames[i] << " � ����������" << endl;
			cout << "2. ������������� ��������� " << setsNames[i] << "  ���������� �������" << endl;
			do {
				cin >> choiceHowCreate;
				if (isCorrectInput()) {
					if (choiceHowCreate != 1 && choiceHowCreate != 2) {
						cout << "������� ���������� ��������!" << endl;
					}
				}
			} while ((choiceHowCreate != 1 && choiceHowCreate != 2) || !isCorrectInput());
			if (choiceHowCreate == 1) {
				system("cls");
				cout << "������� ���������� ��������� � ��������� " << setsNames[i] << endl;
				setSize = U.checkBolMen();
				sets[i].createSet(setSize, U);
			}
			if (choiceHowCreate == 2) {
				system("cls");
				cout << "������� ���������� ��������� � ��������� " << setsNames[i] << endl;
				setSize = U.checkBolMen();
				sets[i].createRandomSet(setSize, U);
			}
		}
		else {
			
		}
	}
}

void Functions(vector<Set>& sets, Set U, vector<char> setsNames)
{
	system("cls");
	cout << "�������� ��������:" << endl;
	cout << "1. �����������" << endl;
	cout << "2. �����������" << endl;
	cout << "3. ��������" << endl;
	cout << "4. �������������� ��������" << endl;
	cout << "5. ����������" << endl;
	int operationChoice;
	do {
		cin >> operationChoice;
		if (isCorrectInput()) {
			if (operationChoice < 1 || operationChoice > 5) {
				cout << "������� ���������� ��������!" << endl;
			}
		}
	} while ((operationChoice < 1 || operationChoice > 5) || !isCorrectInput());
	int setFirstChoice;
	int setSecondChoice;
	switch (operationChoice) {
	case 1:
		cout << "�������� ���������" << endl;
		setFirstChoice = choiceSet()-1;
		cout << "�������� ������ ���������" << endl;
		setSecondChoice = choiceSet() - 1;
		sets[setFirstChoice].intersection(sets[setSecondChoice]);
		break;
	case 2:
		cout << "�������� ���������" << endl;
		setFirstChoice = choiceSet() - 1;
		cout << "�������� ������ ���������" << endl;
		setSecondChoice = choiceSet() - 1;
		sets[setFirstChoice].unification(sets[setSecondChoice]);
		break;
	case 3:
		cout << "�������� ���������" << endl;
		setFirstChoice = choiceSet() - 1;
		cout << "�������� ������ ���������" << endl;
		setSecondChoice = choiceSet() - 1;
		sets[setFirstChoice].difference(sets[setSecondChoice]);
		break;
	case 4:
		cout << "�������� ���������" << endl;
		setFirstChoice = choiceSet() - 1;
		cout << "�������� ������ ���������" << endl;
		setSecondChoice = choiceSet() - 1;
		sets[setFirstChoice].simmDifference(sets[setSecondChoice]);
		break;
	case 5:
		cout << "�������� ���������" << endl;
		setFirstChoice = choiceSet() - 1;
		U.addition(sets[setFirstChoice]);
		break;
	}
}

void isElementInSet(vector<Set>& sets, Set U, vector<char> setsNames)
{
	system("cls");
	cout << "������� �������, ������� ���������� �����" << endl;
	int key;
	do {
		cin >> key;
	} while (!isCorrectInput());
	cout << "�������� ��������� � ������� ����� ����� �������� �������" << endl;
	int setChoice;
	setChoice = choiceSet()-1;
	if (sets[setChoice].isInSet(key)) {
		cout << "������� ������� " << key << " ������ � ��������� " << setsNames[setChoice] << endl;
	}
	else {
		cout << "������� ������� " << key << " �� ��� ������ � ��������� "<< setsNames[setChoice] << endl;
	}
	system("pause");
}


void setIsSubSet(vector<Set>& sets, Set U, vector<char> setsNames)
{
	cout << "�������� ��������� � ������� ����� �����" << endl;
	int setFirstChoice = choiceSet()-1;
	system("cls");
	cout << "�������� ��������� ������� ����� �����" << endl;
	int setSecondChoice = choiceSet()-1;
	if (sets[setFirstChoice].setInSet(sets[setSecondChoice])) {
		cout << "��������� " << setsNames[setSecondChoice] << " �������� ������������� ��������� " << setsNames[setFirstChoice] << endl;
		system("pause");
	}
	else {
		cout << "��������� " << setsNames[setSecondChoice] << " �� �������� ������������� ��������� " << setsNames[setFirstChoice] << endl;
		system("pause");
	}
}
void MainMenu(vector<Set>& sets, Set U, vector<char> setsNames)
{
	int menuChoice;
	do
	{
		system("chcp 1251>NULL");
		system("cls");
		cout << "1. ������ ���������" << endl;
		cout << "2. ��������� �������� ��� �����������" << endl;
		cout << "3. ���������, ����������� �� �������� ������� ���������" << endl;
		cout << "4. ���������, ������ �� ���� ������������ � ������" << endl;
		cout << "0. ����� �� ���������" << endl;
		for (int i = 0; i < 5; ++i)
		{
			sets[i].displaySet(setsNames[i]);
		}
		U.displaySet('U');
		do {
			cin >> menuChoice;
			if (menuChoice != 1 && menuChoice != 2 && menuChoice != 3 && menuChoice != 4 && menuChoice != 0) {
				cout << "������� ���������� ��������!" << endl;
			}
		} while ((menuChoice < 0 || menuChoice > 4) || !isCorrectInput());
		switch (menuChoice) {
		case 1:
			CreateSets(sets, U, setsNames);
			for (int i = 0; i < 5; ++i)
			{
				sets[i].displaySet(setsNames[i]);
			}
			system("pause");
			break;
		case 2:
			Functions(sets, U, setsNames);
			break;
		case 3:
			isElementInSet(sets, U, setsNames);
			break;
		case 4:
			setIsSubSet(sets, U, setsNames);
			break;
		}
	} while (menuChoice != 0);
}