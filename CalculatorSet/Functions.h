#pragma once
#include"Class.h"
#include"Methods.h"
using namespace std;
bool isCorrectInput() {
	if (cin.fail() || cin.peek() != '\n') {
		cin.clear();
		cin.seekg(cin.eof());
		cout << "Ошибка ввода! " << "Введите целое число" << endl;
		return false;
	}
	return true;
}

int choiceSet() {
	cout << "1. Выбрать множество А" << endl;
	cout << "2. Выбрать множество B" << endl;
	cout << "3. Выбрать множество C" << endl;
	cout << "4. Выбрать множество D" << endl;
	cout << "5. Выбрать множество E" << endl;
	int choiceSet;
	do {
		cin >> choiceSet;
		if (isCorrectInput()) {
			if (choiceSet < 1 || choiceSet > 6) {
				cout << "Введите корректное значение!" << endl;
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
		cout << "1. Задать множество " << setsNames[i] << endl;
		cout << "2. Оставить это множество пустым" << endl;
		do {
			cin >> choiceHowCreate;
			if (isCorrectInput()) {
				if (choiceHowCreate != 1 && choiceHowCreate != 2) {
					cout << "Введите корректное значение!" << endl;
				}
			}
		} while ((choiceHowCreate != 1 && choiceHowCreate != 2) || !isCorrectInput());
		int setSize;
		if (choiceHowCreate == 1) {
			system("cls");
			cout << "1. Задать множество " << setsNames[i] << " с клавиатуры" << endl;
			cout << "2. Сгенерировать множество " << setsNames[i] << "  случайными числами" << endl;
			do {
				cin >> choiceHowCreate;
				if (isCorrectInput()) {
					if (choiceHowCreate != 1 && choiceHowCreate != 2) {
						cout << "Введите корректное значение!" << endl;
					}
				}
			} while ((choiceHowCreate != 1 && choiceHowCreate != 2) || !isCorrectInput());
			if (choiceHowCreate == 1) {
				system("cls");
				cout << "Введите количество элементов в множестве " << setsNames[i] << endl;
				setSize = U.checkBolMen();
				sets[i].createSet(setSize, U);
			}
			if (choiceHowCreate == 2) {
				system("cls");
				cout << "Введите количество элементов в множестве " << setsNames[i] << endl;
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
	cout << "Выберете операцию:" << endl;
	cout << "1. Пересечение" << endl;
	cout << "2. Объединение" << endl;
	cout << "3. Разность" << endl;
	cout << "4. Симметрическая разность" << endl;
	cout << "5. Дополнение" << endl;
	int operationChoice;
	do {
		cin >> operationChoice;
		if (isCorrectInput()) {
			if (operationChoice < 1 || operationChoice > 5) {
				cout << "Введите корректное значение!" << endl;
			}
		}
	} while ((operationChoice < 1 || operationChoice > 5) || !isCorrectInput());
	int setFirstChoice;
	int setSecondChoice;
	switch (operationChoice) {
	case 1:
		cout << "Выберете множество" << endl;
		setFirstChoice = choiceSet()-1;
		cout << "Выберете второе множество" << endl;
		setSecondChoice = choiceSet() - 1;
		sets[setFirstChoice].intersection(sets[setSecondChoice]);
		break;
	case 2:
		cout << "Выберете множество" << endl;
		setFirstChoice = choiceSet() - 1;
		cout << "Выберете второе множество" << endl;
		setSecondChoice = choiceSet() - 1;
		sets[setFirstChoice].unification(sets[setSecondChoice]);
		break;
	case 3:
		cout << "Выберете множество" << endl;
		setFirstChoice = choiceSet() - 1;
		cout << "Выберете второе множество" << endl;
		setSecondChoice = choiceSet() - 1;
		sets[setFirstChoice].difference(sets[setSecondChoice]);
		break;
	case 4:
		cout << "Выберете множество" << endl;
		setFirstChoice = choiceSet() - 1;
		cout << "Выберете второе множество" << endl;
		setSecondChoice = choiceSet() - 1;
		sets[setFirstChoice].simmDifference(sets[setSecondChoice]);
		break;
	case 5:
		cout << "Выберете множество" << endl;
		setFirstChoice = choiceSet() - 1;
		U.addition(sets[setFirstChoice]);
		break;
	}
}

void isElementInSet(vector<Set>& sets, Set U, vector<char> setsNames)
{
	system("cls");
	cout << "Введите элемент, который необходимо найти" << endl;
	int key;
	do {
		cin >> key;
	} while (!isCorrectInput());
	cout << "Выберете множество в котором нужно найти введеный элемент" << endl;
	int setChoice;
	setChoice = choiceSet()-1;
	if (sets[setChoice].isInSet(key)) {
		cout << "Искомый элемент " << key << " найден в множестве " << setsNames[setChoice] << endl;
	}
	else {
		cout << "Искомый элемент " << key << " не был найден в множестве "<< setsNames[setChoice] << endl;
	}
	system("pause");
}


void setIsSubSet(vector<Set>& sets, Set U, vector<char> setsNames)
{
	cout << "Выберете множество в котором нужно найти" << endl;
	int setFirstChoice = choiceSet()-1;
	system("cls");
	cout << "Выберете множество которое нужно найти" << endl;
	int setSecondChoice = choiceSet()-1;
	if (sets[setFirstChoice].setInSet(sets[setSecondChoice])) {
		cout << "Множество " << setsNames[setSecondChoice] << " ЯВЛЯЕТСЯ подмножеством множества " << setsNames[setFirstChoice] << endl;
		system("pause");
	}
	else {
		cout << "Множество " << setsNames[setSecondChoice] << " НЕ ЯВЛЯЕТСЯ подмножеством множества " << setsNames[setFirstChoice] << endl;
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
		cout << "1. Задать множества" << endl;
		cout << "2. Выполнить операции над множествами" << endl;
		cout << "3. Проверить, принадлежит ли заданный элемент множеству" << endl;
		cout << "4. Проверить, входит ли одно подмножество в другое" << endl;
		cout << "0. Выход из программы" << endl;
		for (int i = 0; i < 5; ++i)
		{
			sets[i].displaySet(setsNames[i]);
		}
		U.displaySet('U');
		do {
			cin >> menuChoice;
			if (menuChoice != 1 && menuChoice != 2 && menuChoice != 3 && menuChoice != 4 && menuChoice != 0) {
				cout << "Введите корректное значение!" << endl;
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