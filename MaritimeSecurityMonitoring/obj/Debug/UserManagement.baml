   M S B A M L   `   `   `  ����U  QMaritimeSecurityMonitoring, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullG(clr-namespace:MaritimeSecurityMonitoringMaritimeSecurityMonitoring  5      W0clr-namespace:MaritimeSecurityMonitoring.Content"MaritimeSecurityMonitoring.Content  5      /    )MaritimeSecurityMonitoring.UserManagement   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6m(clr-namespace:MaritimeSecurityMonitoring     5      Dcontent0clr-namespace:MaritimeSecurityMonitoring.Content     5        N� Title$  UserManagement��5
         
CommonPage#��[  5       � 	Resources 5      ;  5MaritimeSecurityMonitoring.ReadOnlyToCheckedConverter  rtcc �� 
TargetType �� Property �� Value  EditBox �� Triggers �� Binding �� Path �� Value	 P� Property
 P� Value  
EditButton �� 
TargetType ��Name ��Name �� Triggers �� 
TargetName  DeleteButton J� IsHitTestVisible J� SnapsToDevicePixels �� CornerRadius ��Name  ComboBoxTextBox  ComboBoxToggleButton � ColumnDefinitions � Cursor �� Stretch � Points d�Name �� 	ClickMode d� 	IsChecked �� Mode �� RelativeSource �� SelectionBoxItem �� SelectionBoxItemTemplate ��Name  �� 
IsReadOnly! �� 
IsReadOnly" �Name# �� IsDropDownOpen$ � AllowsTransparency% �Name& �� MaxDropDownHeight' � ActualWidth��%�  &	       '��      '�� �     &	 9    &	 >    &	     '�� �    &	 �
    &	 .    '�� �      5   
   6'   �� 5   
   " ��6   .�5      ��  � ��$ Center=�6;   �� 5       � ��$ 14(�6)   �� 5       � ��$ 30��6'   5      �� 5   
   " ��6   .�5      ��  � ��
 ���� 6+   �� 5       � ��$ 15(�6)   �� 5       � ��$ 30��6'   5      �� 5   
   " ��6    .�5      ��  � ��$ 0q�60   �� 5       � ��
 ���� 6+   �� 5       � ��$ 30��6'   �� 5       � ��$ Center=�69    5      �� 5       6   �� $ ReadOnly� true6@   .a�5      ��  �@��
IsReadOnly . 63   5       �� 5!       6   �� $ ReadOnly�	 false6@   .a�5"      ��  �@��
IsReadOnly .  63   5#      P� 5$      	 �@��
IsReadOnly
 .  . �5%      ��  � ��
 �����63   5&      5(      �� 5)   
   " d�6#   .�5*      ��  � �� 5+      �� 5,      " d�6&   .R�5-      �� $ bd��6!   $��0q�6-   
������ ._�5.      �� $	 img��6$   $��Image\编辑.png��61   5/       50      P� 51      	 �@J�IsMouseOver
 . . �52   "   �� $ bd��6)    � ��
 �����6O   53      P� 54      	 � ��
 . . �55   "   �� $ bd��6)    � ��
 �����6O   56      P� 57      	 �@d�	IsChecked$

 TrueY�6;   . �58   "   �� $ bd��6)    � ��
 �����6O   �� 59   "    �@�ToolTip$ 完成��6<   5:      P� 5;      	 �@d�	IsChecked$
 FalseY�6;   . �5<   "   ��  �@�ToolTip$ 编辑��6<   5=      5?      5A      5B      �� 5C   
   " ��6%   .�5D      ��  � �� 5E      �� 5F      " ��6&   .R�5G      �� $ bd��6!   $��0q�6-   
������ ._�5H      �� 5I       5J      P� 5K      	 �@J�IsMouseOver
 . . �5L   "   �� $ bd��6)    � ��
 �����6O   5M      P� 5N      	 � ��
 . . �5O   "   �� $ bd��6)    � ��
 �����6O   5P      5R      5T      5U      �� 5W   
   " ��6   .�5X      ��  � ��$ Center=�6;   �� 5Y       � ��$ Center=�69   �� 5Z       �@��ClearTypeHint$ Enabled=�6<   �� 5[       � ��$ 0q�60   �� 5\       � ��$ 28��6'   �� 5]       � �� 5^      �� 5_      " ��6&   .R�5`      � #��z��6   .+�5a      �� $ ItemBackground��6%    .  # z 6V   #��z��5b   !   #��z��6U   ���#d9ebf6$ 4��5c   6   �� 5d      $ contentPresenter��6/   #��z��6I   #��z��6l   #��z��5e   +   5f       5g      P� 5h      	 �@��
IsSelected
 . . �5i   "   �� $ ItemBackground��6)    � �� �	#FFA3C5EE6[   5j      P� 5k      	 �@J�IsMouseOver
 . . �5l   "   �� $ ItemBackground��6)    � ��
 �����6[   5m      5o      5q      5r      �� 5t   
   " ��62   .R�5u      �� $ PART_ContentHost��6   |�.  #��z��6A   5v      �� 5w   
   " d�67   .R�5x      �  5y      �� 5z      �� 5{      $��30 �6'   .+�5}      �� $��0��6   $��0q�6)   �� 5      $��1��6   $��0q�6)   
������ $
 Hand��6V   � 5�      $��1��6   $
 Fill=�6*   ���	#FFA3C5EE- �   @KL @@ @T� ��� @KL ��[ $��6 11 9 9q�6n   5�      5�      �� 5�   
   " ��6   .�5�      ��  � �� 5�      �� 5�      " ��6&   .R�5�      � .+�5�      d� $ ToggleButton��6m   $��2��6+   #���  6;   |�.  $ Press=�6�    6�   �� $ IsDropDownOpen�$ TwoWay=� �� *TemplatedParent+6�   �� 5�      $ ContentSite��6^   $��Center=�6/   $��0,0,22,0q�6L   $��Center=�6s   #��z 6�   #��z 6�   #��z��6�    .  69  �� 5�      $ PART_EditableTextBox��6�   $y�Hidden=�6&   #���  6:   $��Center=�6g   $��Center=�6�   |�. 
������ #! z  6�   ��6�   Z� 6�   � 5�      $" Popup��6a   #��z# 6$   $��Bottom=�6N   |�.  $ . $��Slide=�6�   .��5�   "   � $% DropDown��6�   #��z& 6'   #��z' 6W    . .+�5�   &   �� $ DropDownBorder��6-   ���#d9ebf6���	#FFA3C5EE$��1q�6r   $ 5��6�   �� 5�   &   $��0q�63   $��1q�6G    . $
��Auto=�6m   $
��Auto=�6�   ��. .��5�   *   �� 5�   '   5�   #   5�      5�       5�      �� 5�      $
 true��6L    6*   �� $ ReadOnly�.a�5�   "   ��  �@��
IsReadOnly . 6?   5�      �� 5�      $ false��6L    6*   �� $ ReadOnly�.a�5�   "   ��  �@��
IsReadOnly .  6?   5�      P� 5�      	 �@��
IsReadOnly
 . . �5�   "   �� $ ToggleButton��6)    � y�$ 	Collapsed=�6Y   �� 5�   "   $ ContentSite��6)    � ��$ 0q�6T   5�      5�      5�      5�      5�      .��5�      � $��20 15q�6   ( � RowDefinitions( 5�   
   �� 5�      $��* �6   �� 5�      $	��155 �6   .+�5�   
   �� $��0��6     CommonBorder#��[ 6   $��
35 45 35 0q�6D   ._�5�      � $��5q�6    5�      �� 5�      $��* �6'   �� 5�      $
��1.2* �6'   �� 5�      $
��1.5* �6'   �� 5�      $��* �6'   �� 5�      $��* �6'   �� 5�      $
��1.2* �6'   �� 5�      $
��1.2* �6'   �� 5�      $
��1.5* �6'   �� 5�      $��* �6'   .+�5�      � -   5        $% column1��5�   '   $��0��6   6'   � 5�      -   5        $% column2��5�   '   $��1��6   6'   � 5�      -   5        $% column3��5�   '   $��2��6   6'   � 5�      -   5        $% column4��5�   '   $��3��6   6'   � 5�      -   5        $% column5��5�   '   $��4��6   6'   � 5�      -   5        $% column6��5�   '   $��5��6   6'   � 5�      -   5        $% column7��5�   '   $��6��6   6'   � 5�      -   5        $% column8��5�   '   $��7��6   6'   � 5�      -	   5        $% column9��5�   '   $��8��6   6'   �� 5�      -
   5        $��UserListView��5�   0   $��10��6   
������ $��0q�6u   $
��-3 0q�6�   ��6D   �� ) �� View) 5�      �� 5�      .P�5�      �� $��编号��6-   * �� Width* 69   �� + �� ElementName$+ column1��$ ActualWidth�, �� DisplayMemberBinding, 6p   �� *ID+�� 5�      $��	用户名��6-   * 6:   �� $+ column2��$ ActualWidth�- �� CellTemplate- 5�   "   �� 5�   &   .R�5�   *   �� -   5        #��[ 5�   2   . �� 	MaxLength$. 20��6�   ��6S   �� *
UserName+6�   5�   '   5�      �� 5�      $��密码��6-   * 69   �� $+ column3��$ ActualWidth�- 5�   "   �� 5�   &   .R�5�   *   �� #��[ 62   $. 20��6m   ��6S   �� *
Password+6m   5�   '   5�      �� 5�      $��角色类型��6-   * 6;   �� $+ column4��$ ActualWidth�- 5�   "   �� 5�   &   .R�5�   *   �� $��80��63   / �� SelectedIndex/ 6>   �� *Role+.@�5�   .   �� .��6;   	管理员6@   �� 5�   .   .��6;   	工程师6@   �� 5�   .   .��6;   	操作员6@   �� 5�   .   .��6;   	观察员6@   5�   +   5�   '   5�      �� 5�      $��职位��6-   * 69   �� $+ column5��$ ActualWidth�- 5�   "   �� 5�   &   .R�5�   *   �� #��[ 62   $. 20��6m   ��6S   �� *
Position+6m   5�   '   5�      �� 5�      $��部门��6-   * 69   �� $+ column6��$ ActualWidth�- 5�   "   �� 5�   &   .R�5�   *   �� #��[ 62   $. 20��6o   ��6S   �� *
Department+6o   5�   '   5�      �� 5�      $��联系电话��6-   * 6;   �� $+ column7��$ ActualWidth�- 5�   "   �� 5�   &   .R�5�   *   �� #��[ 62   $. 11��6j   ��6S   �� *Phone+6j   5�   '   5�      �� 5�      $��邮箱��6-   * 69   �� $+ column8��$ ActualWidth�- 5�   "   �� 5�   &   .R�5�   *   �� #��[ 62   $. 30��6i   ��6S   �� *Mail+6i   5   '   5     �� 5     * 6-   �� $+ column9��$ ActualWidth�- 5  "   �� 5  &   .R�5  *   � .+�5  .   d� -   5        #��[ 5  s   $��0 0 15 0q�6�   ��6N   �� $ ID� 5  ;   �� *
ReadOnly+$ TwoWay=�0 �� UpdateSourceTrigger$0 PropertyChanged=�1 �� 	Converter#1 [ �� 5	  .   -   5        #��[ 5	  o   ��6J   �� $ ID�.��5
  2   �� $��Image\删除4.png��68   5  /   5  +   5  '   5     5     5     5     5     � 5  
   $��1��6   .+�5     � .+�5     3   -MaritimeSecurityMonitoring.Content.IconButton  2  ,System.Windows.Markup.XmlAttributeProperties2  XmlSpace2 preserve6�   3   -MaritimeSecurityMonitoring.Content.IconButton3   Click$3 AddTargetClick��6A   4   ImagesSource$4 Image\增加.png��6%   5   Text$5 新  增��6X   $��16(�6d   $��90��6r   $��30��6}   $��
170 15 0 0q�6�   6�   5     5     5     5     