   M S B A M L   `   `   `  ���� U  QMaritimeSecurityMonitoring, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullG(clr-namespace:MaritimeSecurityMonitoringMaritimeSecurityMonitoring  /    )MaritimeSecurityMonitoring.DateTimePicker   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     6m(clr-namespace:MaritimeSecurityMonitoring     -     � 	Resources     UpTriButton �� 
TargetType �Name �� Stretch � Points �� Color �� Opacity �� Triggers P� Property	 P� Value
 �� 
TargetName �� Property �� Value  BottomTriButton  CornerTextBox �� CornerRadius ��Name  TextBoxErrorTemp �� 
TargetType �� Triggers �� ElementName �� Path��%�  &	        &	 &    &	 H    &	 �    �� " ��.R�� .+�� $ ButtonPolygon��$
 Fill=� �   ��� @KL ��� ��� 
�������$��2������ $
 Gray��$	 0.4Q� P�  �@J�IsMouseOver	 . . ��� $
 ButtonPolygon�� � ��
 �   �P�  � ��	 . . ��� $
 ButtonPolygon�� � �� �	#FFA3C5EE�� " ��.R�� .+�� $ ButtonPolygon��$
 Fill=� �   @KL ��� ��� 
�������$��2������ $
 Gray��$	 0.4Q� P�  �@J�IsMouseOver	 . . ��� $
 ButtonPolygon�� � ��
 �   �P�  � ��	 . . ��� $
 ButtonPolygon�� � �� �	#FFA3C5EE�� " ��.R��� $��1q����	#FFA3C5EE$ 2��._��� $ PART_ContentHost��$��Center=��� " �� P�  �@=�HasError	 . . ���  �@=�ErrorTemplate �� .R�]� ��. .+��� $	��Top=�
���  ��$��14(�$
��Bold"�$��8 0 14 0q����� $ 	MyAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent��� 
���  ��$��2q�$��22��._��� $��	MyAdorner��.���� $��1q����	#FFA3C5EE���#d9ebf6$ 5��._�� $��2�� � ColumnDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+��� -   $��tb��$��0��$��13(�$��Center=�$��Center=�$��60��$��5q�d� -   $��cButton��$��2��$��0q����#d9ebf6$��30��$��5 2 5 2q� d� 	IsChecked �� $ cPopup��$ IsOpen�.���� $��Calendar.png��� -    �Name$ cPopup�� � 	StaysOpen .  ��.  $��Bottom=� � HorizontalOffset$	 -80�� � VerticalOffset$ 1�� � AllowsTransparency . $
��Fade=� � PlacementTarget �� $ cButton��.���� $��1q����	#FFA3C5EE���#d9ebf6$ 3��._�� $��1�� � RowDefinitions �� $��* ��� $
��Auto �.+�&   System.Windows.Controls.Calendar  -     Name$ 	Calendar1��$��0�����	#FFA3C5EE$
��0 -3q�� $��1��.+��� $��1q����	#FFA3C5EE
�������$ 0 0 2 2��._�� $��2�� �� $��* ��� $��* ��� $��* �.+��� $��0��$��20��$
��Left=�$��5 2 0 -2q�时:�� -    ��Name$ HourSet��$��0��#��[ #��[ $��20��$
��Left=�$��Right=�$��25,2,0,2q�.������ $
 Hour� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�  �� NotifyOnValidationError  . ! �� ValidationRules! ;   5MaritimeSecurityMonitoring.NumberValidationRuleForInt  
"   Max$" 23��
#   Min$# 0��.���� -   $��0��
$ � Tag$
$ hour��#��[  $��Right=�$	��Top=�$��8��$��0,2,0,0q��� -   $��0��$
$ hour��#��[ $��Right=�$��Bottom=�$��8��$��0,0,0,2q��� $��1��$��20��$
��Left=�$��5 2 0 -2q�分:�� -	   $ 	MinuteSet��$��1��#��[ #��[ $��20��$
��Left=�$��Right=�$��25,2,0,2q�.������ $ Minute�$ TwoWay=�$ PropertyChanged=�  . !   $" 59��$# 0��.���� -
   $��1��$$ minute��#��[  $��Right=�$	��Top=�$��8��$��0,2,0,0q��� -   $��1��$$ minute��#��[ $��Right=�$��Bottom=�$��8��$��0,0,0,2q��� $��2��$��20��$
��Left=�$��5 2 0 -2q�秒:�� -   $ 	SecondSet��$��2��#��[ #��[ $��20��$
��Left=�$��Right=�$��25,2,0,2q�.������ $ Second�$ TwoWay=�$ PropertyChanged=�  . !   $" 59��$# 0��.���� -   $��2��$$ second��#��[  $��Right=�$	��Top=�$��8��$��0,2,0,0q��� -   $��2��$$ second��#��[ $��Right=�$��Bottom=�$��8��$��0,0,0,2q�� $��1�� �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� -   % ��Name$
% year��$��0��$��0000 /��$��13(�$��Center=�$��5 0 0 0q��� -   $% month��$��1��$
��00 /��$��13(�$��Center=�$��3 0 0 0q��� -   $	% day��$��2��$��00��$��13(�$��Center=�$��3 0 0 0q��� -   $
% hour��$��3��$
��00 :��$��13(�$��Center=�$��8 0 0 0q��� -   $% minute��$��4��$
��00 :��$��13(�$��Center=�$��3 0 0 0q��� -   $% second��$��5��$��00��$��13(�$��Center=�$��3 0 0 0q�