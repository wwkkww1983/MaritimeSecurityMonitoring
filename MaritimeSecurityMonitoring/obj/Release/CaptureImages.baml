   M S B A M L   `   `   `  ���� U  QMaritimeSecurityMonitoring, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullG(clr-namespace:MaritimeSecurityMonitoringMaritimeSecurityMonitoring  .    (MaritimeSecurityMonitoring.CaptureImages   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6m(clr-namespace:MaritimeSecurityMonitoring     -     � Title$  图片抓取��$	��600��$	��600��$	��600��$	��500��$	��500��$	��500�� � WindowStyle$
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
���  ��$��14(�$
��Bold"�$��Center=����� $ 	MyAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent��� 
���  ��$��2q�$��93��._��� $��	MyAdorner����  J� InputBindings �� 
 �� Key$	 Esc�� �� Command# [  J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [ .���  � RowDefinitions �� $��40 ��� $��* �.+��� #��[  $��20(�
�������.��图片抓取�� -   $��22��$��22��$��0 0 10 0q�$��Right=�$��0q�.���� $��Image/Close_new.png������  �� Color$ 	#FF4A79D8���� $��1��$��0q�
�������$ 0 0 8 8��._��  �� $��5* ��� $��* �.+��� $��0��$��1q�
�������$ 8��$��50 40 50 30q�._��  �� $
��3.5* ��� $��* �.+��� $��0��$��10,10,27,10q����� -   Picture��� $��	0,232,0,0q�$��2�� � ColumnDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��1��$��20(�$��Center=�$��59,13,49,40q�MMSI�� -   $��MMSIText��$��1��#��[ $��28��$��20(�$��Center=�$��Center=�$��136,11,141,40q�$��2��.������ $
 MMSI� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� NotifyOnValidationError .  �� ValidationRules ;   5MaritimeSecurityMonitoring.NumberValidationRuleForInt  
   Max$ 
2147483647��
   Min$ 1��.���� -   $��2��#��[ $��25��$��60��$��20(�
�������$��220,29,54,25q�.��识别�� $��20(�$��Center=�$��59,50,218,3q�$��3��	船舷号�� -   $��
boatNumber��$��1��#��[ $��28��$��20(�$��Center=�$��Center=�$��136,47,141,4q�  �� 	MaxLength$  20��$��2��.������ $ 
boatNumber�$ TwoWay=�$ PropertyChanged=� .  J  DMaritimeSecurityMonitoring.NumberValidationRuleForCharacterAndNumber  .��� $��1�� �� $��* ��� $
��Auto ��� $
��Auto ��� $��* �.+��� -   $��1��#��[ $��38��$	��100��$��20(�
�������$	��Top=�$��0 0 80 0q�.��保存�� -	   $��2��#��[ $��38��$	��100��$��20(�
�������$	��Top=�.��取消