   M S B A M L   `   `   `  ����F  BBeautySalon, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:BeautySalonBeautySalon  5   	       BeautySalon.AuthWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:BeautySalon     5   	     � Title$  
AuthWindow��5   	   $	��450��6   $	��400��6)    � Icon$ /beauty_logo.png��65    � 
ResizeMode$ NoResize=�5	   	   .��5
      � $��Center=�6   $��Center=�6(    � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      $��1* �6   .+�5   
   � $��0��6   $��50q�6    5      �� 5      �� 5      �� 5      �� 5      .+�5      �� $��0��6   $��Роль��6!   �� 5      -   5         ��Name$ RoleComboBox��5       �� 
IsEditable$
 True��6-   $��1��6?   $��Center=�6L   .@�5      ��  �� 
IsSelected$
 True��6   
 � Tag$ 0��61   $��Обычный режим��69   �� 5      $ 1��6   $ ��Администратор��6'   5      �� 5      $��2��6   $��Пароль��6!   G� 5      -   5         G�Name$ PasswordBox��5      $��3��6/   5      �� 5   
   -   5        	 ��Name$	 EnterButton��5      $��1��6&   $��50q�63   $��Вход��6?   6N   5      5       