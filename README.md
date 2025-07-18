This repo explores wide character interaction with consoles.

We write white on green (Attributes 47).

The first char is `你` (which has double console width)

When using `WriteConsoleOutputW` from `kernel32.dll` we are advised to use a 'skip' char after the wide one.


|     Terminal     |    `' '`   | `'\0'`  | <none> |
|:----------------:|:----------:|-------------|-----|
| Alacritty        |    <img width="40" height="17" alt="image" src="https://github.com/user-attachments/assets/e6ce7b21-97f6-4b9b-b77c-05f6864f6046" />        |    <img width="32" height="17" alt="image" src="https://github.com/user-attachments/assets/29ae3729-fa0e-4729-b255-4174f30d9661" />         |  <img width="32" height="17" alt="image" src="https://github.com/user-attachments/assets/1405ddd0-4e2c-46fd-8645-dd5a3eb84f16" />
 |


