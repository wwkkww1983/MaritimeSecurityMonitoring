   M S B A M L   `   `   `  ���� U  QMaritimeSecurityMonitoring, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullW0clr-namespace:MaritimeSecurityMonitoring.Content"MaritimeSecurityMonitoring.Content  G(clr-namespace:MaritimeSecurityMonitoringMaritimeSecurityMonitoring  1    +MaritimeSecurityMonitoring.WhiteListSetting   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Dcontent0clr-namespace:MaritimeSecurityMonitoring.Content     :local(clr-namespace:MaritimeSecurityMonitoring       N� Title$  WhiteListSetting��   
CommonPage#��[   � 	Resources ;  5MaritimeSecurityMonitoring.ReadOnlyToCheckedConverter  rtcc �� 
TargetType �� Property �� Value  EditBox �� Triggers �� Binding �� Path �� Value	 P� Property
 P� Value  
EditButton �� 
TargetType ��Name ��Name �� Triggers �� 
TargetName  DeleteButton��%�  &	       '��      '�� X     &	 �     &	 �    &	 �      �� " ��.���  � ��$ Center=���  � ��$ 14(���  � ��$ 30���� " ��.���  � ��
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
 �����.��� $��20 15q� � RowDefinitions �� $��* ��� $	��155 �.+��� $��0��  CommonBorder#��[ $��
35 45 35 0q�._�� $��5q� � ColumnDefinitions �� $
��0.4* ��� $��* ��� $
��0.5* ��� $
��0.5* ��� $
��0.8* ��� $
��0.8* ��� $
��0.8* ��� $
��0.8* ��� $
��0.6* �.+�� -    �Name$ column1��$��0��� -   $ column2��$��1��� -   $ column3��$��2��� -   $ column4��$��3��� -   $ column5��$��4��� -   $ column6��$��5��� -   $ column7��$��6��� -   $ column8��$��7��� -	   $ column9��$��8���� -
   $��WhiteListView��$��9��
������ $��0q�$
��-3 0q�����  �� View �� .P��� $��编号�� �� Width ��  �� ElementName$ column1��$ ActualWidth� �� DisplayMemberBinding �� *ID+�� $��船舶MMSI编码�� �� $ column2��$ ActualWidth� �� *MMSI+�� $��	船舷号�� �� $ column3��$ ActualWidth� �� CellTemplate �� .R��� -   #��[  �� 	MaxLength$ 20������ *Number+�� $	��IMO�� �� $ column4��$ ActualWidth� �� .R��� #��[ $ 11������ *IMO+�� $��呼号�� �� $ column5��$ ActualWidth� �� .R��� #��[ $ 64������ *
CallSign+�� $��船舶名称�� �� $ column6��$ ActualWidth� �� .R��� #��[ $ 64������ *Name+�� $��船舶部门�� �� $ column7��$ ActualWidth� �� .R��� #��[ $ 64������ *
Department+�� $��船舶用途�� �� $ column8��$ ActualWidth� �� .R��� #��[ $ 64������ *Usage+��  �� $ column9��$ ActualWidth� �� .R�� .+�d� -   #��[ $��0 0 15 0q����� $ ID� d� 	IsChecked �� *
ReadOnly+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� 	Converter# [ �� -   #��[ ���� $ ID�.���� $��Image\删除1.png��� $��1��.+�� .+�3   -MaritimeSecurityMonitoring.Content.IconButton  2  ,System.Windows.Markup.XmlAttributeProperties  XmlSpace preserve3   -MaritimeSecurityMonitoring.Content.IconButton   Click$ AddTargetClick��   ImagesSource$ Image\增加.png��    Text$  新  增��$��16(�$��90��$��30��$��
170 15 0 0q�