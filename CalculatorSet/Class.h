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
	void addElement(int element); //метод добавления элемента в множество
	void unification(const Set& other) const; //метод объединения
	void intersection(const Set& other)const; //метод пересечения
	void difference(const Set& other)const; //метод разности
	void simmDifference(const Set& other)const; //метод симметрической разности
	void addition(const Set& other)const; //метод дополнения
	void createSet(int size, Set& univ); //метод создания множества
	bool checkUniv(int element); // метод проверки на вхождение в универсум
	void displaySet(char n); //метод вывода множества на экран
	void displayOper(); //метод вывода результата операций на экран
	bool isInSet(int element) const; //метод проверки уникальности элемента в множестве
	void createUnSet(); //метод создания универсального множества 
	void createRandomSet(int size, Set& univ); //метод создания множества через генератор случайных чисел
	bool setInSet(Set& other); //метод нахождения подмножества в множестве
	int checkBolMen(); //метод проверки максимума размера массива
	bool isCorrectInput(); //метод проверки на корректность ввода
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
