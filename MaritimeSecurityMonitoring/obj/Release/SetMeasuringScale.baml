   M S B A M L   `   `   `  ���� U  QMaritimeSecurityMonitoring, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullG(clr-namespace:MaritimeSecurityMonitoringMaritimeSecurityMonitoring  8    2MaritimeSecurityMonitoring.Video.SetMeasuringScale   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6m(clr-namespace:MaritimeSecurityMonitoring     -     � Title$  指定比例尺��$	��400��$	��400��$	��400��$	��420��$	��420��$	��420�� � WindowStyle$
 None=� � AllowsTransparency . 
������  � 
ResizeMode$ NoResize=� � 	Resources    CornerLabel �� 
TargetType �� CornerRadius  CornerButton ��Name �� Triggers	 P� Property
 P� Value �� 
TargetName �� Property �� Value  TextBoxErrorTemp �� 
TargetType �� Triggers �� ElementName �� Path 
 Cancel��%�  &	        &	 o     &	 f    &	 �    �� " ��.R��� $��0q�$ 8,8,0,0�����	#FF4A79D8._��� #��z��$
��Left=�$��Center=�$��10 0 0 0q��� " ��.R��� $ bd��$��0q�$ 5 5 5 5�����	#FF4A79D8._��� #��z��$��Center=�$��Center=� P� 	 �@J�IsMouseOver
 . . ��� $ bd�� � �� �	#FF6D9DFFP� 	 � ��
 . . ��� $ bd�� � �� �	#FF005AE2�� " �� P� 	 �@=�HasError
 . . ���  �@=�ErrorTemplate �� .R�]� ��. .+��� $��Bottom=�
���  ��$��16(�$
��Bold"�$��Center=����� $ 	MyAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent��� 
���  ��$��2q�$	��164��._��� $��	MyAdorner����  J� InputBindings �� 
 �� Key$	 Esc�� �� Command# [  J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [ .���  � RowDefinitions �� $��40 ��� $��* �.+��� #��[  $��20(�
�������.��指定比例尺�� -   $��22��$��22��$��0 0 10 0q�$��Right=�$��0q�.���� $��Image/Close_new.png������  �� Color$ 	#FF4A79D8���� $��1��$��0q�
�������$ 0 0 8 8��._��  �� $��4* ��� $��* �.+��� $��0��$��1q�
�������$ 8��$��40 35 40 25q�._��  �� $
��0.3* ��� $��* ��� $��* ��� $��* ��� $
��0.6* ��� $��* ��� $
��0.5* �.+�	� -    	�Name$
 rad1��$��1��$��20(�$��Center=�$��Center=� d� 	IsChecked$
 TrueY�$��62 0 0 0q�.��选择比例尺：� $��2��$��Center=�$��Center=�.+��� $��20(�$��Center=�1：�� -    ��Name$	 com��$	��160��$��20(�$��Center=�{�. .@��� .��1�� .��10�� .��100�� .��500�� .��1000��  �� 
IsSelected . .��5000�� .��10000�� .��50000�� .��100000�� .��500000�� .��	1000000�� .��	5000000�� .��
10000000�� .��
50000000�� .��	100000000	� -   $��3��$��20(�$��Bottom=�$��Center=�$��62 0 0 5q�.��指定比例尺：�� $��4��$��16(�$��Center=�$��62 0 0 0q�（< 2147483648）� $��5��$��Center=�$��Center=�.+��� $��20(�$��Center=�1：�� -    ��Name$ test1��#��[ $	��160��$��20(�$��Center=�{�.  .������ $ value� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�  �� NotifyOnValidationError  . ! �� ValidationRules! ;   5MaritimeSecurityMonitoring.NumberValidationRuleForInt  -   rule��
"   Min$" 1��
#   Max$# 
2147483647��.��� $��1��$ � ColumnDefinitions$ �� $��* ��� $
��Auto ��� $
��Auto ��� $��* �.+��� -	   $��1��#��[ $��35��$��90��$��20(�
�������$	��Top=�$��0 0 70 0q�.��确定�� -
   $��2��#��[ $��35��$��90��$��20(�
�������$	��Top=�.��取消