#!/bin/bash

read -p "请输入您的对象的姓名：" girlfriend || exit 1
read -p "请输入您的姓名：" me || exit 1

if [ $EUID = 0 ]; then
  me=root
fi

echo "$girlfriend是一个美少女"
echo "她喜欢$me"
echo "从此两人过上了幸福快乐的生活"
