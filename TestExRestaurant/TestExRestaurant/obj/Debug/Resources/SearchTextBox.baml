   M S B A M L   `   `   `  ����K  GTestExRestaurant, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:TestExRestaurant.ControlsTestExRestaurant.Controls  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   SearchTextBox_Background  �� Color  SearchTextBox_Foreground  SearchTextBox_Border �� 
StartPoint �� EndPoint � Color � Offset ! SearchTextBox_BorderMouseOver " SearchTextBox_SearchIconBorder & "SearchTextBox_SearchIconBackground , (SearchTextBox_SearchIconBorder_MouseOver 0 ,SearchTextBox_SearchIconBackground_MouseOver , (SearchTextBox_SearchIconBorder_MouseDown 0	 ,SearchTextBox_SearchIconBackground_MouseDown  
 SearchTextBox_LabelTextColor-    'TestExRestaurant.Controls.SearchTextBox �� 
TargetType �� Property �� Value �� 
TargetType	 ��Name
 �Name � ColumnDefinitions �� RelativeSource �� Path ��Name ��Name J� Opacity ��Name �� Triggers P� Property P� Value �� 
TargetName ]� 
Conditions �� Property �� Value �� 
SourceName�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      -l'clr-namespace:TestExRestaurant.Controls  5      %�  &	        &	      &	 >     &	     &	 �    &	 �    &	     &	 �    &	 �    &		 E    &	
 B    '   `    7   7  7  7 
 7  7  7  7  7  7  7  7  �� 5      $  White��67   �� 5      $  Black��67   �� 5      $	 0,0&�67   $	 0,1&�6H   .��5   
   � $ 	#FFABADB3��6   $
 0.05Q�6)   � 5   
   $ 	#FFE2E3EA��6   $
 0.07Q�6)   � 5	   
   $ 	#FFE3E9EF��6   $ 1Q�6)   5
      �� 5      $	 0,0&�6@   $	 0,1&�6Q   .��5   
   � $ 	#FF5C97C1��6   $
 0.05Q�6)   � 5   
   $ 	#FFB9D7EB��6   $
 0.07Q�6)   � 5   
   $ 	#FFC7E2F1��6   $ 1Q�6)   5      �� 5      $  White��6=   �� 5      $  White��6A   �� 5      $	 0,0&�6K   $	 0,1&�6\   .��5   
   � $ 	#FFFFFFFF��6   $ 0Q�6)   � 5   
   $ 	#FFE5F4FC��6   $ 1Q�6)   5      �� 5      $	 0,0&�6O   $	 0,1&�6`   .��5   
   � $ 	#FFE7F5FD��6   $ 0Q�6)   � 5   
   $ 	#FFD2EDFC��6   $	 0.5Q�6)   � 5   
   $ 	#FFB6E3FD��6   $
 0.51Q�6)   � 5   
   $ 	#FF9DD5F3��6   $ 1Q�6)   5      �� 5      $	 0,0&�6K   $	 0,1&�6\   .��5   
   � $ 	#FFFFFFFF��6   $ 0Q�6)   � 5   
   $ 	#FFE5F4FC��6   $ 1Q�6)   5      �� 5       $	 0,0&�6O   $	 0,1&�6`   .��5!   
   � $ 	#FFE7F5FD��6   $ 0Q�6)   � 5"   
   $ 	#FFD2EDFC��6   $	 0.5Q�6)   � 5#   
   $ 	#FFB6E3FD��6   $
 0.51Q�6)   � 5$   
   $ 	#FF9DD5F3��6   $ 1Q�6)   5%      �� 5&      $
  Gray��6;   �� 5(      "   6-   .�5)   
   ��  � ��8   6'   �� 5*   
    � ��8  6(   �� 5+   
    � ��8  6'   �� 5,   
    � ��$ 1q�6,   �� 5-   
    �@J�SnapsToDevicePixels . 60   �� 5.   
    �@  	LabelText$ Search��6&   �� 5/   
    �@�FocusVisualStyle 6-   Z� �� 50   
    �@  LabelTextColor8  6+   �� 51   
    � �� 52      �� 53      "   6"   .R�54      �� $	 Border��6   #��z��55      #��z��56      #��z��57      ._�58      � $
 
LayoutGrid��6    59      �� 5:   "   $��* �63   �� 5;   "   ��63   ��  �� *TemplatedParent+$ ActualHeight�.+�5>      �� $ PART_ContentHost��66   $��2q�6+   $��0��6P   �� 5?      $ 	LabelText��5@   !   $��2q�5A   !   $��0��5B   !   $��2,0,0,0q�5G   !   $��Italic$�5H   !   ��5C   !   ��  �� *TemplatedParent+$ LabelTextColor���5E   !   ��  �� *TemplatedParent+$ 	LabelText�5H   !   �� 5I      $	 PART_SearchIconBorder��5J   !   $��1��5K   !   $��1q�5L   !   $��Stretch=�5M   !   $��Stretch=�5N   !   $ 0Q�5O   !   8�� 8�� ._�5R      �� $ 
SearchIcon��5S   !   $
��None=�5T   !   $��15��5U   !   $��15��5V   !   $��Center=�5W   !   $��Center=�5X   !   5[      5\      5]       5^      P� 5_       �@J�IsMouseOver . . �5`      �� 8   � ��6<   5a      P� 5b       �@J�IsKeyboardFocusWithin . . �5c      �� 8   � ��6<   5d      P� 5e       �@  HasText . . �5f      �� $ 	LabelText��6;    � y�$ Hidden=�6R   5g      ]� 5h       5i      �� 5j   "    �@  HasText . 6?   �� 5k   "    �@  
SearchMode$ Instant=�6B   ./�5m      �� $ 
SearchIcon��5o   !    � ��$H Bpack://application:,,,/TestExRestaurant;component/Images/clear.png��5p   !   �� 5q      $ PART_SearchIconBorder��5s   !    �@J�Opacity$ 1Q�5t   !   5u      ]� 5v       5w      �� 5x   "   $ PART_SearchIconBorder��5y   %    �@J�IsMouseOver . 5z   %   �� 5{   "    �@  HasText . 6?   ./�5}      �� $ PART_SearchIconBorder��5~   !   8   � ��5   !   �� 5�      $ PART_SearchIconBorder��5�   !   8 	  � ��5�   !   5�      ]� 5�       5�      �� 5�   "   $ PART_SearchIconBorder��6C    �@J�IsMouseOver . 6f   �� 5�   "    �@  IsMouseLeftButtonDown . 6M   �� 5�   "    �@  HasText . 6?   ./�5�      �� $ PART_SearchIconBorder��5�   !    �@��Padding$ 2,0,0,0q�5�   !   �� 5�      $ PART_SearchIconBorder��5�   !   8 
  � ��5�   !   �� 5�      $ PART_SearchIconBorder��5�   !   8   � ��5�   !   5�      5�      5�      5�      5�      