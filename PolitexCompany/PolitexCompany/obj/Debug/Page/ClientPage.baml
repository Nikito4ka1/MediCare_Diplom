   M S B A M L   `   `   `  ����I  EPolitexCompany, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:PolitexCompanyPolitexCompany  5          PolitexCompany.ClientPage   5      ^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QScottPlot.WPF, Version=4.1.63.0, Culture=neutral, PublicKeyToken=e53b06131e34a3aaR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      (localclr-namespace:PolitexCompany  5        N� Title$  
ClientPage��5
      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $��60 �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dGridClients��5         AutoGenerateColumns .     
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$	 №��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 60   �� *id+  5      $ Имя��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6K    62   �� *name+	   ElementStyle	 5      �� 5      
 �� 
TargetType"
 ��6    .�5      ��  �� Property � �� �� Value$
 Wrap=�6=   5      5        5      $ Фамилия��6%   $	 100 6R    66   �� *	surname+	 5      �� 5      "
 ��6    .�5      ��  � ��$
 Wrap=�6=   5      5!        5"      $ Отчество��6%   $	 150 6V    67   �� *
patronymic+	 5#      �� 5$      "
 ��6    .�5%      ��  � ��$
 Wrap=�6=   5&      5(        5)      $ 
Адрес��6%   $	 150 6P    64   �� *	address+	 5*      �� 5+      "
 ��6    .�5,      ��  � ��$
 Wrap=�6=   5-      5/        50      $! Номер телефона��6%   $	 125 6W    6=   �� *phone+	 51      �� 52      "
 ��6    .�53      ��  � ��$
 Wrap=�6=   54      56        57      $ Email��6%   $	 200 6N    64   �� *email+	 58      �� 59      "
 ��6    .�5:      ��  � ��$
 Wrap=�6=   5;      5=      4  .System.Windows.Controls.DataGridTemplateColumn  5?      $	 130 6)      CellTemplate 5@      �� 5A      .R�5B      �� -   5        $��Изменить��5B   %   ���#1c92d2
�������6a   5C      5E        5F      $	 125 6)    5G      �� 5H      .R�5I      �� -   5        $��Удалить��5I   %   ���#1c92d2
�������6`   5J      5L      5O      �� 5Q   
   -   5         ��Name$ 	btnCreate��5Q   :   ���#1c92d2
�������$%��Добавить Клиента��6e   $��Right=�6�   $��1��6�   $��Bottom=�6�   $��30��6�   $	��158��6�   �� 5R   
   -   5         ��Name$ tbSearh��5R      $
��Left=�6#   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Поиск��6>      
IsFloating . $��
340,10,0,0q�6�   $��1��6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��220��6�   $��44��6  5T      5U      