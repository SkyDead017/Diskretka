#pragma once
#include <iostream>
#include<vector>
#include<algorithm>
#include<string>
#include<stdlib.h>
#include<time.h>
using namespace std;
class Set
{
public:
	Set();
	~Set();
	void setName(string name);
	string getName();
	void addElement(int element); //����� ���������� �������� � ���������
	void unification(const Set& other) const; //����� �����������
	void intersection(const Set& other)const; //����� �����������
	void difference(const Set& other)const; //����� ��������
	void simmDifference(const Set& other)const; //����� �������������� ��������
	void addition(const Set& other)const; //����� ����������
	void createSet(int size, Set& univ); //����� �������� ���������
	bool checkUniv(int element); // ����� �������� �� ��������� � ���������
	void displaySet(char n); //����� ������ ��������� �� �����
	void displayOper(); //����� ������ ���������� �������� �� �����
	bool isInSet(int element) const; //����� �������� ������������ �������� � ���������
	void createUnSet(); //����� �������� �������������� ��������� 
	void createRandomSet(int size, Set& univ); //����� �������� ��������� ����� ��������� ��������� �����
	bool setInSet(Set& other); //����� ���������� ������������ � ���������
	int checkBolMen(); //����� �������� ��������� ������� �������
	bool isCorrectInput(); //����� �������� �� ������������ �����
private:
	vector<int> elements{};
	string sName;
};

Set::Set()
{
	
}

Set::~Set()
{
}
