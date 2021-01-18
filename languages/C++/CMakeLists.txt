# 设置可使用的最低版本的 CMake 
# 要查找 cmake 版本请运行
# $ cmake --version
cmake_minimum_required(VERSION 3.5)

# 设置项目名称
project (create_gril_friend)

# 创建带有指向所有要编译的 cpp 文件的链接的 source 变量
set(SOURCES 
    src/main.cpp
    src/Person.cpp
    src/Girl.cpp
)

# 增加一个可执行文件
add_executable(demo ${SOURCES})

# 设置此目标的构建命令中应 include 的目录
# 当运行 g++时，这些将作为 -I/directory/path/ 被 include
target_include_directories(demo
    PRIVATE 
        ${PROJECT_SOURCE_DIR}/include
)
