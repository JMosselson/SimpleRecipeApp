   M S B A M L   `   `   `  ����  
ProgPoeGui    ProgPoeGui.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  
Recipe App��5   	    � WindowStyle$
 None=�5   	    � WindowState$ 	Maximized=�5	   	   .��5
      � ��5   
   �� 5       �� ImageSource$ /progbackground.jpg��6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   � $��0��6    5      �� 5      $
��Auto �6    �� 5      $��* �6    .+�5      �� $��0��6   $��Center=�6!   $��Center=�6E   $��0,20,0,0q�6g   .��5      �� $��20(�6   �� 5       $ �Welcome to the Recipe App!��6   $
��Bold"�6<    �� TextDecorations$ 	Underline{�6N   
����� �6j   5!      5"      �� 5%      $��1��6    �� Orientation$ 
Horizontal=�6&   $��Center=�6?   $	��Top=�6\   $��0,20,0,0q�6t   .+�5&      �� -   5         ��Name$ CreateRecipeButton��5&      $��Create Recipe��65   $��20q�6n   $��5q�6{   
����� �6�   �� 5'      -   5        $ ViewRecipesButton��5'      $��View Recipe��64   $��20q�6j   $��5q�6w   
����� �6�   �� 5(      -   5        $ DeleteRecipeButton��5(      $��Delete Recipe��65   $��20q�6n   $��5q�6{   
����� �6�   �� 5)      -   5        $ FilterRecipeButton��5)      $��Filter Recipe��65   $��20q�6n   $��5q�6{   
����� �6�   �� 5*      -   5        $ 
QuitButton��5*      $
��Quit��6-   $��20q�6U   $��5q�6b   
����� �6m   5+      5,      �� 5/   
   $��1��6   $��Center=�6   $��Center=�6A   $��0,0,0,20q�6c   .��50      �� $��20(�6   �� 51      $�Done By Jordan Mosselson��6   $
��Bold"�66   $ 	Underline{�6H   
����� �6d   52      53      54      55      