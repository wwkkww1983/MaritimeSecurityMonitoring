   M S B A M L   `   `   `  ���� U  QMaritimeSecurityMonitoring, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullW0clr-namespace:MaritimeSecurityMonitoring.Content"MaritimeSecurityMonitoring.Content  ]3clr-namespace:MaritimeSecurityMonitoring.Converters%MaritimeSecurityMonitoring.Converters  0    *MaritimeSecurityMonitoring.Content.NetLine   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Blocal0clr-namespace:MaritimeSecurityMonitoring.Content     Ac3clr-namespace:MaritimeSecurityMonitoring.Converters     -     >�Name$  netLine�� � 	Resources E  ?MaritimeSecurityMonitoring.Converters.BoolToVisibilityConverter   boolToVisibilityConverter % !reversalBoolToVisibilityConverter   TrueVisibility   FalseVisibility��%9   &	        &	          $ Hidden=�$ Visible=�.��� $��11�� � ColumnDefinitions �� $��1* ��� $��10 ��� $��1* �.+�A� $
��Left=�
���  ��$��3��$��3��y���  �� ElementName$ netLine�� �� Path$ IsBroken� �� 	Converter# [  �� 
���  ��$��1��$��
2, 0, 0, 0q�$��Stretch=�y��� $ netLine��$ IsBroken�# [  �� $��1��$��11��$��10��y��� $ netLine��$ IsBroken�# [  .+��� 
���  ��$��1��$��12��$��Center=� �� Left$ 1��
	 �� Top$	 2��z��� 
 �� Angle$
 30Q� �� CenterX$ 0Q� �� CenterY$ 0Q��� 
���  ��$��1��$��12��$��Center=�$ 0��$	 8��z��� $	
 -30Q�$ 0Q�$ 0Q�A� $��2��$��Right=�
���  ��$��3��$��3��y��� $ netLine��$ IsBroken�# [  �� $��2��
���  ��$��1��$��
0, 0, 2, 0q�$��Stretch=�y��� $ netLine��$ IsBroken�# [  A� $
��Left=�
��� � �$��3��$��3��y��� $ netLine��$ IsBroken�# [ �� $��3��$��
2, 0, 2, 0q�$��1��$��Stretch=�
��� � �$��Center=�y��� $ netLine��$ IsBroken�# [ A� $��2��$��Right=�
��� � �$��3��$��3��y��� $ netLine��$ IsBroken�# [ 