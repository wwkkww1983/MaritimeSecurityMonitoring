   M S B A M L   `   `   `  ���� U  QMaritimeSecurityMonitoring, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullG(clr-namespace:MaritimeSecurityMonitoringMaritimeSecurityMonitoring  W0clr-namespace:MaritimeSecurityMonitoring.Content"MaritimeSecurityMonitoring.Content  /    )MaritimeSecurityMonitoring.UserManagement   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     6m(clr-namespace:MaritimeSecurityMonitoring     Dcontent0clr-namespace:MaritimeSecurityMonitoring.Content       N� Title$  UserManagement��   
CommonPage#��[   � 	Resources ;  5MaritimeSecurityMonitoring.ReadOnlyToCheckedConverter  rtcc �� 
TargetType �� Property �� Value  EditBox �� Triggers �� Binding �� Path �� Value	 P� Property
 P� Value  
EditButton �� 
TargetType ��Name ��Name �� Triggers �� 
TargetName  DeleteButton J� IsHitTestVisible J� SnapsToDevicePixels �� CornerRadius ��Name  ComboBoxTextBox  ComboBoxToggleButton � ColumnDefinitions � Cursor �� Stretch � Points d�Name �� 	ClickMode d� 	IsChecked �� Mode �� RelativeSource �� SelectionBoxItem �� SelectionBoxItemTemplate ��Name  �� 
IsReadOnly! �� 
IsReadOnly" �Name# �� IsDropDownOpen$ � AllowsTransparency% �Name& �� MaxDropDownHeight' � ActualWidth��%=  &	       '��      '�� X     &	 �     &	 �    &	 �    '�� [    &	 D    &	 {    '�� M      �� " ��.���  � ��$ Center=���  � ��$ 14(���  � ��$ 30���� " ��.���  � ��
 ���� ��  � ��$ 15(���  � ��$ 30���� " ��.���  � ��$ 0q���  � ��
 ���� ��  � ��$ 30����  � ��$ Center=� ��  �� $ ReadOnly� true.a���  �@��
IsReadOnly . ��  �� $ ReadOnly�	 false.a���  �@��
IsReadOnly .  P� 	 �@��
IsReadOnly
 .  . ���  � ��
 ������� " d�.���  � �� �� " d�.R��� $ bd��$��0q�
������ ._��� $	 img��$��Image\编辑.png�� P� 	 �@J�IsMouseOver
 . . ��� $ bd�� � ��
 �����P� 	 � ��
 . . ��� $ bd�� � ��
 �����P� 	 �@d�	IsChecked$

 TrueY�. ��� $ bd�� � ��
 �������  �@�ToolTip$ 完成��P� 	 �@d�	IsChecked$
 FalseY�. ���  �@�ToolTip$ 编辑���� " ��.���  � �� �� " ��.R��� $ bd��$��0q�
������ ._���  P� 	 �@J�IsMouseOver
 . . ��� $ bd�� � ��
 �����P� 	 � ��
 . . ��� $ bd�� � ��
 ������� " ��.���  � ��$ Center=���  � ��$ Center=���  �@��ClearTypeHint$ Enabled=���  � ��$ 0q���  � ��$ 28����  � �� �� " ��.R�� #��z��.+��� $ ItemBackground�� .  # z #��z��#��z�����#d9ebf6$ 4���� $ contentPresenter��#��z��#��z��#��z�� P� 	 �@��
IsSelected
 . . ��� $ ItemBackground�� � �� �	#FFA3C5EEP� 	 �@J�IsMouseOver
 . . ��� $ ItemBackground�� � ��
 ������� " ��.R��� $ PART_ContentHost��|�.  #��z���� " d�.R��  �� �� $��30 �.+��� $��0��$��0q��� $��1��$��0q�
������ $
 Hand��� $��1��$
 Fill=����	#FFA3C5EE- �   @KL @@ @T� ��� @KL ��[ $��6 11 9 9q��� " ��.���  � �� �� " ��.R�� .+�d� $ ToggleButton��$��2��#���  |�.  $ Press=� �� $ IsDropDownOpen�$ TwoWay=� �� *TemplatedParent+�� $ ContentSite��$��Center=�$��0,0,22,0q�$��Center=�#��z #��z #��z�� .  �� $ PART_EditableTextBox��$y�Hidden=�#���  $��Center=�$��Center=�|�. 
������ #! z  ��Z� � $" Popup��#��z# $��Bottom=�|�.  $ . $��Slide=�.��� $% DropDown��#��z& #��z'  . .+��� $ DropDownBorder�����#d9ebf6���	#FFA3C5EE$��1q�$ 5���� $��0q�$��1q� . $
��Auto=�$
��Auto=���. .����  �� $
 true�� �� $ ReadOnly�.a���  �@��
IsReadOnly . �� $ false�� �� $ ReadOnly�.a���  �@��
IsReadOnly .  P� 	 �@��
IsReadOnly
 . . ��� $ ToggleButton�� � y�$ 	Collapsed=��� $ ContentSite�� � ��$ 0q�.��� $��20 15q�( � RowDefinitions( �� $��* ��� $	��155 �.+��� $��0��  CommonBorder#��[ $��
35 45 35 0q�._�� $��5q� �� $��* ��� $
��1.2* ��� $
��1.5* ��� $��* ��� $��* ��� $
��1.2* ��� $
��1.2* ��� $
��1.5* ��� $��* �.+�� -   $% column1��$��0��� -   $% column2��$��1��� -   $% column3��$��2��� -   $% column4��$��3��� -   $% column5��$��4��� -   $% column6��$��5��� -   $% column7��$��6��� -   $% column8��$��7��� -	   $% column9��$��8���� -
   $��UserListView��$��10��
������ $��0q�$
��-3 0q����� ) �� View) �� .P��� $��编号��* �� Width* �� + �� ElementName$+ column1��$ ActualWidth�, �� DisplayMemberBinding, �� *ID+�� $��	用户名��* �� $+ column2��$ ActualWidth�- �� CellTemplate- �� .R��� -   #��[ . �� 	MaxLength$. 20������ *
UserName+�� $��密码��* �� $+ column3��$ ActualWidth�- �� .R��� #��[ $. 20������ *
Password+�� $��角色类型��* �� $+ column4��$ ActualWidth�- �� .R��� $��80��/ �� SelectedIndex/ �� *Role+.@��� .��	管理员�� .��	工程师�� .��	操作员�� .��	观察员�� $��职位��* �� $+ column5��$ ActualWidth�- �� .R��� #��[ $. 20������ *
Position+�� $��部门��* �� $+ column6��$ ActualWidth�- �� .R��� #��[ $. 20������ *
Department+�� $��联系电话��* �� $+ column7��$ ActualWidth�- �� .R��� #��[ $. 11������ *Phone+�� $��邮箱��* �� $+ column8��$ ActualWidth�- �� .R��� #��[ $. 30������ *Mail+�� * �� $+ column9��$ ActualWidth�- �� .R�� .+�d� -   #��[ $��0 0 15 0q����� $ ID� �� *
ReadOnly+$ TwoWay=�0 �� UpdateSourceTrigger$0 PropertyChanged=�1 �� 	Converter#1 [ �� -   #��[ ���� $ ID�.���� $��Image\删除4.png��� $��1��.+�� .+�3   -MaritimeSecurityMonitoring.Content.IconButton  2  ,System.Windows.Markup.XmlAttributeProperties2  XmlSpace2 preserve3   -MaritimeSecurityMonitoring.Content.IconButton3   Click$3 AddTargetClick��4   ImagesSource$4 Image\增加.png��5   Text$5 新  增��$��16(�$��90��$��30��$��
170 15 0 0q�