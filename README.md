This repo explores wide character interaction with consoles.

We write white on green (Attributes 47).

The first char is `你` (which has double console width)

When using `WriteConsoleOutputW` from `kernel32.dll` we are advised to use a 'skip' char after the wide one.

The test cases are as follows

| Test Case | Written |
|:---------:|:--------:|
| `' '`| `['你', ' ', 'c','d']` |
| `'\0'`| `['你', '\0', 'c','d']` |
| &lt;none&gt; | `['你', 'c','d']` |
| modern | Uses `WriteConsoleW` and `SetConsoleTextAttribute` instead (write as string) |

Results:

|     Terminal     |    `' '`   | `'\0'`  | &lt;none&gt; |  modern |
|:----------------:|:----------:|-------------|-----|------|
| Alacritty        |    <img width="40" height="33" alt="image" src="https://github.com/user-attachments/assets/3b8e67c2-7c3e-445e-a55f-167b16e353a4" />    |    <img width="32" height="32" alt="image" src="https://github.com/user-attachments/assets/0f505417-13cd-4358-beaf-79c83bbd0243" /> | <img width="32" height="32" alt="image" src="https://github.com/user-attachments/assets/073f7d7f-701e-48f2-b806-43a96ee206a3" /> | <img width="40" height="32" alt="image" src="https://github.com/user-attachments/assets/07a36f77-1250-424e-b528-164bd94d2624" />
  |
 | Windows Terminal | <img width="70" height="54" alt="image" src="https://github.com/user-attachments/assets/75836c98-d947-4919-9249-816ad7ed2db7" /> | <img width="70" height="52" alt="image" src="https://github.com/user-attachments/assets/f7ebec79-84eb-4195-adb3-1561fc0f672d" /> | <img width="56" height="53" alt="image" src="https://github.com/user-attachments/assets/f8189101-68ff-4c82-b936-814b5a51141a" />
| cmd.exe (NSimSun font) | <img width="52" height="52" alt="image" src="https://github.com/user-attachments/assets/0a83b395-bacf-4ef8-b2c5-124945e32789" /> | <img width="52" height="53" alt="image" src="https://github.com/user-attachments/assets/ac215526-4c06-4769-842a-659a0fbe895b" /> | <img width="39" height="52" alt="image" src="https://github.com/user-attachments/assets/3dd0b634-a08e-4603-ad6b-36c5a95a6535" /> |



