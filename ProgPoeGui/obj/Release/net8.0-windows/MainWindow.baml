   M S B A M L   `   `   `  ����   
ProgPoeGui    ProgPoeGui.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       � Title$  
Recipe App�� � WindowStyle$
 None=� � WindowState$ 	Maximized=�.��� ����  �� ImageSource$ /progbackground.jpg�� � RowDefinitions �� $��* ��� $
��Auto �.+�� $��0�� �� $
��Auto ��� $��* �.+��� $��0��$��Center=�$��Center=�$��0,20,0,0q�.���� $��20(��� $ �Welcome to the Recipe App!��$
��Bold"� �� TextDecorations$ 	Underline{�
����� ��� $��1�� �� Orientation$ 
Horizontal=�$��Center=�$	��Top=�$��0,20,0,0q�.+��� -    ��Name$ CreateRecipeButton��$��Create Recipe��$��20q�$��5q�
����� ��� -   $ ViewRecipesButton��$��View Recipe��$��20q�$��5q�
����� ��� -   $ DeleteRecipeButton��$��Delete Recipe��$��20q�$��5q�
����� ��� -   $ FilterRecipeButton��$��Filter Recipe��$��20q�$��5q�
����� ��� -   $ 
QuitButton��$
��Quit��$��20q�$��5q�
����� ��� $��1��$��Center=�$��Center=�$��0,0,0,20q�.���� $��20(��� $�Done By Jordan Mosselson��$
��Bold"�$ 	Underline{�
����� �