   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  6-   -   5          �Name$
  Form��5   	    � Title$ 
MainWindow��5	   	   $	��455��6   $
��1074��6)    � 
ResizeMode$ NoResize=�66    � WindowStartupLocation$ CenterScreen=�6L   .��5
      � $��10,0,0,0q�6   $y�Visible=�6    � ColumnDefinitions 5   
   �� 5      $	��510 �6   6-   �� 5      $��* �6   6+    � RowDefinitions 5   
   �� 5      $��50 �6   6*   �� 5      $��* �6   6)   .+�5   
   �� $��0��6   $��1��6%   $��1��62   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��20��62   $��	0,10,10,0q�6>   $��Center=�5      �� 5      $ 
Horizontal=�6   $��20��62   $��0,10,0,0q�6>   $��Center=�6P   �� 5      $ 
Horizontal=�6   $��20��62   $��0,10,0,0q�6>   $��Center=�6P   �� 5      -   5         ��Name$
 Sort��5      $
��Sort��66   
�������$	��200��5      $��	0,20,0,20q�6%   $��23��68   5      &   System.Windows.Controls.DataGrid  5      -   5          Name$ Table��5      $��96��6&   $	��510��5      $��0,20,0,0q�5      6S   �� 5       -   5        	 ��Name$		 Log��5       $	��510��6#   
 �� TextWrapping$

 Wrap=�6/   $��80��5!      $
��Auto��6'   $
��Auto=�5"      $��5q�6I   .��6T   5#      5$      �� 5%   
   $��1��6   $��0,0,0,0q�6"   $��1��63   .+�5&      �� $ 
Horizontal=�6   .+�5'      �� -   5        $
 Save��5'      $��40��6'   $��40��62   
����� � � ToolTip$ SaveDataBase��5)      {�. $��Center=�5*   &   $��	150,0,0,0q�6C   .��5+      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 File=�6.   
���   �$��15��6M   $��15��6X   5,      �� 5-      -   5        $	 Add��5-      $��1��6&   $��1��66   $��	120,0,0,0q�5.      $��40��6(   $��40��63   $��Center=�5/      
���/���$ SaveDataBase��51      {�52      �� *	IsChecked+ �� ElementName$ manager��.��53        $	 Add=�6.   
���   �$��15��6L   $��15��6W   $��Center=�54      55      56      �� 57      -   5         ��Name$ Editors��57      $��
Specialist��6(   
���   �$	��100��59      $
��Auto��6#   .��5:      �� $
��Auto��6   $
��Auto��6,   .@�5;      �� .+�5<      	� -   5         	�Name$ manager��5<   &    	� 	GroupName$ Editor��5=   &   $��Manager��69   $��0,0,0,0q�5>   &    d� 	IsChecked$
 TrueY�67   	� 5?      -	   5        $ 
consultant��5?   &   $ Editor��5@   &   $��
Consultant��69   $��0,10,0,0q�5A   &   $ FalseY�68   5B      5C      5D      5E      �� 5F   
   $��1��6   $��0,0,0,0q�6"   $��1��63   .+�5G      R� -
   5         R�Name$ Accounts��5G      $��1��6)   $��1��69   $
��Auto��5H      $��50,50,50,50q�6$   $	��100��69   $��10(�5J       � ContextMenu 5K      �� 5L      -   5        $��cm��5L   "    �� 	StaysOpen . .@�5M      m� -   5        $	��Add��5M   #   60   m� 5N      -   5        $��Delete��5N   #   63   m� 5O      -   5         m�Name$ 	MoneyMenu��5O   #   $��Replace money from...��66   6U   5P      5R      �� 5S      $��Account info��6   $
��Auto��6-   $��
50,0,50,50q�6<   .��5T      �� -   5         ��Name$ AccountInfo��5T      $
��Wrap=�61   5U      5V      5W      5X      5Y      