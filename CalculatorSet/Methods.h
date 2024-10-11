#pragma once
#include"Class.h"
//проверка уникальности
bool Set::isInSet(int element) const {
	return (find(elements.begin(), elements.end(), element) != elements.end());
}
//проверка на нахождение в универсуме
bool Set::checkUniv(int element) {
	return (find(elements.begin(), elements.end(), element) != elements.end());

}

void Set::setName(string name) {
	sName = name;
}
string Set::getName() {
	return sName;
}
//поиск подмножества в множестве
bool Set::setInSet(Set& other) {
	if (other.elements.size() != 0) {
		for (int i = 0; i < other.elements.size(); i++) {
			if (find(elements.begin(), elements.end(), other.elements[i]) == elements.end()) {
				return false;
			}
		}
		return true;
	}
	else { return true; }
}
//проверка на корректность ввода
bool Set::isCorrectInput() {
	if (cin.fail() || cin.peek() != '\n') {
		cin.clear();
		cin.seekg(cin.eof());
		cout << "Ошибка ввода! " << "Введите целое число" << endl;
		return false;
	}
	return true;
}
//проверка максимума размера массива
int Set::checkBolMen() {
	int size;
	do {
		cin >> size;
		if (isCorrectInput()) {
			if (elements.size() < size) {
				cout << "Количество элементов множества превышает допустимое значение!\nВведите значение <= " << elements.size() << endl;
			}
		}
	} while ((elements.size() < size) || !isCorrectInput());
	return size;
}
//Создание множества
void Set::createSet(int size, Set& univ) {
	int element;
	cout << "Введите " << size << " элемента(ов):" << endl;
	for (int i = 0; i < size; i++) {
		cin >> element;
		if (isCorrectInput()) {
			if (!isInSet(element) && univ.checkUniv(element)) {
				elements.push_back(element);
			}
			else {
				if (isInSet(element)) {
					cout << "Ошибка, введен повторяющийся элемент. Введите пожалуйста уникальный элемент для этого множества!" << endl;
					i--;
				}
				else {
					cout << "Ошибка, введен элемент, не содержащийся в универсальном множестве.\nВведите пожалуйста элемент из универсального множества!" << endl;
					i--;
				}
			}
		}
		else {
			i--;
		}
	}
}
//заполнение множества случайнми числами
void Set::createRandomSet(int size, Set& univ) {
	srand(time(NULL));
	int element;
	for (int i = 0; i < size; i++) {
		element = univ.elements[0] + rand() % (univ.elements[univ.elements.size() - 1] - univ.elements[0] + 1);
		if (!isInSet(element)) {
			elements.push_back(element);
		}
		else {
			i--;
		}

	}
}
//создание универсального множества
void Set::createUnSet() {
	int start, finish;
	do {
		cin >> start >> finish;
		if (isCorrectInput()) {
			if (start <= finish) {
				for (int i = start; i <= finish; i++) {
					elements.push_back(i);
				}
			}
			else {
				cout << "Введите корректное значение!(начало<конца)" << endl;
			}
		}
	} while (start > finish || !isCorrectInput());
}

//Добавление элементов
void Set::addElement(int element) {
	if (!isInSet(element)) {
		elements.push_back(element);
	}
}
//вывод множеств
void Set::displaySet(char n) {
	cout << n << "= ";
	cout << '{';
	for (int i = 0; i < elements.size(); i++) {
		cout << elements[i];
		if (i < elements.size() - 1) {
			cout << ", ";
		}

	}
	cout << '}' << endl;
}
//вывод результатов операции
void Set::displayOper() {
	cout << '{';
	for (int i = 0; i < elements.size(); i++) {
		cout << elements[i];
		if (i < elements.size() - 1) {
			cout << ", ";
		}

	}
	cout << '}' << endl;
}
//пересечение
void Set::intersection(const Set& other)const {
	Set result;                                               //новое множество для результата
	for (int i = 0; i < elements.size(); i++) {
		if (other.isInSet(elements[i])) {                    //проверяем содержится ли элемент в другом множестве
			result.addElement(elements[i]);                  //если содержится, то добавляем его в результат
		}
	}
	cout << "Результат пересечения двух множеств: ";
	result.displayOper();
	system("pause");
}
//объединение
void Set::unification(const Set& other)const {
	Set result = *this;                                      //копируем текущее множество в результат
	for (int i : other.elements) {
		result.addElement(i);                  //добавляем элементы другого множества
	}
	cout << "Результат объединения двух множеств: ";
	result.displayOper();
	system("pause");
}
//разность
void Set::difference(const Set& other)const {
	Set result;
	for (int i = 0; i < elements.size(); i++) {
		if (!other.isInSet(elements[i])) {                    //проверяем содержится ли элемент в другом множестве
			result.addElement(elements[i]);                  //если содержится, то добавляем его в результат
		}
	}
	cout << "Результат разности двух множеств: ";
	result.displayOper();
	system("pause");
}
//симметрическая разность
void Set::simmDifference(const Set& other)const {
	Set result;
	for (int i = 0; i < elements.size(); i++) {
		if (!other.isInSet(elements[i])) {                   //добавление элементво текущего множества
			result.addElement(elements[i]);
		}
	}
	for (int i : other.elements) {
		if (!isInSet(i)) {
			result.addElement(i);
		}
	}
	cout << "Результат симметрической разности двух множеств: ";
	result.displayOper();
	system("pause");
}
//дополнение
void Set::addition(const Set& other)const {
	Set result;
	for (int i = 0; i < elements.size(); i++) {
		if (!other.isInSet(elements[i])) {                    //проверяем содержится ли элемент в другом множестве
			result.addElement(elements[i]);                  //если содержится, то добавляем его в результат
		}
	}
	cout << "Результат дополнения: ";
	result.displayOper();
	system("pause");
}