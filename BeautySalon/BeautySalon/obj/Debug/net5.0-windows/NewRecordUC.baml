   M S B A M L   `   `   `  ����F  BBeautySalon, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:BeautySalonBeautySalon  5          BeautySalon.NewRecordUC   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:BeautySalon     5      -   5        .��5      �   � RowDefinitions  5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��2* �6   .+�5   
   �� -   5         ��Name$
 Exit��5      $��
Назад��5      $��0��5      $
��Left=�5      $��Center=�6,   $��Center=�5      $��Center=�65   $��10q�5      5      �� 5    
   $��ФИО��6   $��1��5!      $��0��6   $
��Left=�5"      $��Center=�6+   $��Center=�5#      $��Center=�64   $��10q�5$      �� 5%   
   $��Услуга��6   $��2��5&      $��0��6   $
��Left=�5'      $��Center=�6+   $��Center=�5(      $��Center=�64   $��10q�5)      �� 5*   
   $)��#Дата и время записи��6   $��3��5+      $��0��6   $
��Left=�5,      $��Center=�6+   $��Center=�5-      $��Center=�64   $��10q�5.      �� 5/   
   $��Коментарий��6   $��4��50      $��0��6   $
��Left=�51      $��Center=�6+   $��Center=�52      $��Center=�64   $��10q�53      �� 55   
   -   5         ��Name$ ClientCB��55      $��1��56      $��1��6    $��Center=�57      $��Center=�58      $��Center=�67   $��10q�59       �� 
IsEditable$
 True��5:      �� 5;   
   -   5        $ 	ServiceCB��5;      $��2��5<      $��1��6    $��Center=�5=      $��Center=�5>      $��Center=�67   $��10q�5?      $
 True��5@      �� 5A   
    �� Orientation$ 
Horizontal=�6   $��3��5B      $��1��6"   $��5q�5C      .+�5D      (  "System.Windows.Controls.DatePicker  -   5          Name$ DateDP��5D      $��Center=�6)   � 5E      $��70��6   $��5q�6    5F      �� 5G      �� 5H      $
��auto �6'   �� 5I      .+�5K      �� -   5         ��Name$ HoursTB��5K       �� 	MaxLength$ 2��6+   	 �� MaxLines$	 1��69   $��0��5L      $��Stretch=�5M      $��Center=�68   $��3q�5N      �� 5O      $��:��6   $��1��5P      $��Stretch=�5Q      $��Center=�66   �� 5R      -   5        $ MinutsTB��5R      $ 2��6,   $	 1��6:   $��2��5S      $��Stretch=�5T      $��Center=�68   $��3q�5U      5V      5W      �� 5X   
   -   5        $ 	CommentTB��5X      $��4��5Y      $��1��6   $��Stretch=�5Z      $��Stretch=�60   $��Center=�5[      $��Center=�66   $��10q�5\      �� 5]   
   -	   5        $ AddNewRecord��5]      $#��Добавить запись��5^      $��5��5_      $��0��6   $��2��6.   $��Center=�5`      $��Stretch=�6.   $��Center=�5a      $��Center=�65   $��10q�5b      5c      5d      5e      