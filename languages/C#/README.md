

## Demo 演示

### 方法一
使用 Visual Studio 2019 打开 `Begins.sln` 选择 `YouAndYourGirlfriendsDemo` 作为启动项目， 运行程序。

### 方法二
使用 PowerShell 命令行， 在 `.\create-girl-friend` 目录下执行如下命令。

```PowerShell
cd .\languages\C#\src\Beings\YouAndYourGirlfriendsDemo\

dotnet run
```

## API

### 已完成 API
`People.FallInLove`: 默认跟最近处的对象，坠入爱河
`People.FallInLoveWith`: 指定某个人，坠入爱河,适用于同时跟多个人处对象的情况
`People.BreakUp`: 默认跟最近处的对象，结束关系
`People.BreakUpWith`指定某个人，结束彼此的关系,适用于同时跟多个人处对象的情况
`People.ToMarry`：默认跟最近处的对象，结婚。
`People.ToMarryWith`: 指定和某个人结婚。

### 未完成 API

`People.ToLick[With]`
`People.ToKill[With]`
`People.ToMakeLove[With]`

