#pragma once
#include"Class.h"
//�������� ������������
bool Set::isInSet(int element) const {
	return (find(elements.begin(), elements.end(), element) != elements.end());
}
//�������� �� ���������� � ����������
bool Set::checkUniv(int element) {
	return (find(elements.begin(), elements.end(), element) != elements.end());

}

void Set::setName(string name) {
	sName = name;
}
string Set::getName() {
	return sName;
}
//����� ������������ � ���������
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
//�������� �� ������������ �����
bool Set::isCorrectInput() {
	if (cin.fail() || cin.peek() != '\n') {
		cin.clear();
		cin.seekg(cin.eof());
		cout << "������ �����! " << "������� ����� �����" << endl;
		return false;
	}
	return true;
}
//�������� ��������� ������� �������
int Set::checkBolMen() {
	int size;
	do {
		cin >> size;
		if (isCorrectInput()) {
			if (elements.size() < size) {
				cout << "���������� ��������� ��������� ��������� ���������� ��������!\n������� �������� <= " << elements.size() << endl;
			}
		}
	} while ((elements.size() < size) || !isCorrectInput());
	return size;
}
//�������� ���������
void Set::createSet(int size, Set& univ) {
	int element;
	cout << "������� " << size << " ��������(��):" << endl;
	for (int i = 0; i < size; i++) {
		cin >> element;
		if (isCorrectInput()) {
			if (!isInSet(element) && univ.checkUniv(element)) {
				elements.push_back(element);
			}
			else {
				if (isInSet(element)) {
					cout << "������, ������ ������������� �������. ������� ���������� ���������� ������� ��� ����� ���������!" << endl;
					i--;
				}
				else {
					cout << "������, ������ �������, �� ������������ � ������������� ���������.\n������� ���������� ������� �� �������������� ���������!" << endl;
					i--;
				}
			}
		}
		else {
			i--;
		}
	}
}
//���������� ��������� ��������� �������
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
//�������� �������������� ���������
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
				cout << "������� ���������� ��������!(������<�����)" << endl;
			}
		}
	} while (start > finish || !isCorrectInput());
}

//���������� ���������
void Set::addElement(int element) {
	if (!isInSet(element)) {
		elements.push_back(element);
	}
}
//����� ��������
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
//����� ����������� ��������
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
//�����������
void Set::intersection(const Set& other)const {
	Set result;                                               //����� ��������� ��� ����������
	for (int i = 0; i < elements.size(); i++) {
		if (other.isInSet(elements[i])) {                    //��������� ���������� �� ������� � ������ ���������
			result.addElement(elements[i]);                  //���� ����������, �� ��������� ��� � ���������
		}
	}
	cout << "��������� ����������� ���� ��������: ";
	result.displayOper();
	system("pause");
}
//�����������
void Set::unification(const Set& other)const {
	Set result = *this;                                      //�������� ������� ��������� � ���������
	for (int i : other.elements) {
		result.addElement(i);                  //��������� �������� ������� ���������
	}
	cout << "��������� ����������� ���� ��������: ";
	result.displayOper();
	system("pause");
}
//��������
void Set::difference(const Set& other)const {
	Set result;
	for (int i = 0; i < elements.size(); i++) {
		if (!other.isInSet(elements[i])) {                    //��������� ���������� �� ������� � ������ ���������
			result.addElement(elements[i]);                  //���� ����������, �� ��������� ��� � ���������
		}
	}
	cout << "��������� �������� ���� ��������: ";
	result.displayOper();
	system("pause");
}
//�������������� ��������
void Set::simmDifference(const Set& other)const {
	Set result;
	for (int i = 0; i < elements.size(); i++) {
		if (!other.isInSet(elements[i])) {                   //���������� ��������� �������� ���������
			result.addElement(elements[i]);
		}
	}
	for (int i : other.elements) {
		if (!isInSet(i)) {
			result.addElement(i);
		}
	}
	cout << "��������� �������������� �������� ���� ��������: ";
	result.displayOper();
	system("pause");
}
//����������
void Set::addition(const Set& other)const {
	Set result;
	for (int i = 0; i < elements.size(); i++) {
		if (!other.isInSet(elements[i])) {                    //��������� ���������� �� ������� � ������ ���������
			result.addElement(elements[i]);                  //���� ����������, �� ��������� ��� � ���������
		}
	}
	cout << "��������� ����������: ";
	result.displayOper();
	system("pause");
}