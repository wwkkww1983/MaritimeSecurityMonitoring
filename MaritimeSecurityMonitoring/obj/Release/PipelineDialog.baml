   M S B A M L   `   `   `  ���� U  QMaritimeSecurityMonitoring, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullG(clr-namespace:MaritimeSecurityMonitoringMaritimeSecurityMonitoring  /    )MaritimeSecurityMonitoring.PipelineDialog   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6m(clr-namespace:MaritimeSecurityMonitoring     -     � Title$  管道区域设置��$	��350��$	��350��$	��350��$	��350��$	��350��$	��350�� � WindowStyle$
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
���  ��$��2q�$��58��._��� $��	MyAdorner����  J� InputBindings �� 
 �� Key$	 Esc�� �� Command# [  J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [ .���  � RowDefinitions �� $��40 ��� $��* �.+��� #��[  $��20(�
�������.��管道区域设置�� -   $��22��$��22��$��0 0 10 0q�$��Right=�$��0q�$y�	Collapsed=�.���� $��Image/Close_new.png������  �� Color$ 	#FF4A79D8���� $��1��$��0q�
�������$ 0 0 8 8��._��  �� $
��3.5* ��� $��* �.+��� $��0��$��1q�
�������$ 8��$��40 30q�._��  �� $��* ��� $��* ��� $��* � � ColumnDefinitions �� $��* ��� $
��1.2* �.+��� $��0��$��0��$��20(�$��Center=�$��Center=�$��	20 25 0 0q�区域名称�� -   $��pipelineName��$��0��$��1��$��20(�$��Center=�$��Center=�$��	5 25 30 0q� �� 	MaxLength$ 10���� $��1��$��0��$��20(�$��Center=�$��Center=�$��20 0 0 0q�管道宽度� $��1��$��1�� �� $��* ��� $
��Auto �.+��� -   $��pipelineWidth��$��0��#��[ $��20(�$��Center=�$��Center=�$��5 0 5 0q�.������ $ width� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� NotifyOnValidationError .  �� ValidationRules =   7MaritimeSecurityMonitoring.NumberValidationRuleForFloat  -   rule��
   Min$ 0.00001��
    Max$	  100��.���� $��1��$��20(�$��Center=�$��0 0 30 0q�米(m)�� $��2��$��0��$��20(�$��Center=�$��Center=�$��	20 0 0 25q�区域描述�� -   $	��log��$��2��$��1��$��20(�$��Center=�$��Center=�$��	5 0 30 25q�$ 50��� $��1�� �� $��* ��� $
��Auto ��� $
��Auto ��� $��* �.+��� -   $��1��#��[ $��35��$��90��$��20(�
�������$	��Top=�$��0 0 0 0q�.��确定