   M S B A M L   `   `   `  ����  FACULTATIVE REINSURANCE1    +FACULTATIVE_REINSURANCE.View.AttachmentView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5        � 	Resources  5         TextBoxStyle �� BasedOn �� 
TargetType  
LabelStyle  GridRowStyle��%�   '��       7   '��      7  '�� :     7  �� 5	   
   8   " ��68   �� 5
   
   8   " ��66   �� 5   
   8   " ��68   5      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5      $	��180 �6   �� 5      $��30 �6   �� 5      $��30 �6    � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6   $��
Email Id :��6.   6E   �� 5   
   $��1��6   $��0��6   $��Attachment Files :��6-   6L   �� 5   
   -   5        $��txtEmail��5      $��0��6"   $��1��6/   $
��Left=�6?   $��5,0,0,0q�6Z   .��6k   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5         	EventName$ 	LostFocus��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6-   �� *LostFocusCommand+	   CommandParameter	 5   -   �� 
 �� ElementName$
 txtEmail�� �� Path$
 Text�5       .��5!   &   5"      �� 5#   
   $��1��6   $��1��6"    �� Orientation$ 
Horizontal=�62   .+�5$      �� $��25��6   $��60��6"   $��5,0,0,0q�6-   ��6>   �� *ButtonCommand+��5%      �� 5&      $��Center=�6    $	��0,3q�6;   $��Browse��6H   5(      �� 5)      -   5        $��ErrorMessage��5)      $
��Auto��6,   
���  ��$
��Left=�6J   $��Center=�6e   $��5,0,0,0q�5*      ��6)   �� *ErrorMessage+5=      5>      �� 5@   
   $��5q�6   $��2��6   $��2��6)   $��1q�6=     BorderBrushColur#��[ 6Q   $y�Visible=�6�   ._�5A      �� .��5B      �� $��5q�6F   ��6   �� *AttactmentList+��5C      �� 5D      .R�5E      �� $ 
Horizontal=�6)   .+�5F   "   �� $��panelBorder��6*   ._�5G   &   �� $��stackAttachment��6J   $ 
Horizontal=�61   .+�5H   *   �� $��txtFilename��64   $��CharacterEllipsis=�6a   $��3,0,0,0q�6�   $
��Auto��6�   $
��Auto��6�   ��6G   �� *
FileName+5I   +   �� 5J   *   $��20��65   $
��Auto��6A   $��3,0,2,0q�6}   ��6N   �� *
FileSize+ �� StringFormat$ ({0})��6}   5K   '   5L   #   �� 5M   "   $��txtClose��6f   $��x��6,   $��3,0,0,2q�65   $
��Bold"�6F   $��12(�6X    J� InputBindings 5N   &   d� 5O   *    d� MouseAction$ 	LeftClicke�67    �� Command 6O   �� *#!DataContext.MouseLeftClickCommand+ �� RelativeSource �� *FindAncestor+ �� AncestorType" �� �� CommandParameter 5P   7   �� $
 txtFilename��$
 Text�5R   #   5S       �� Triggers 5T      P� 5U   "    P� 
SourceName$ txtClose��6*    P� Property �@J�IsMouseOver P� Value . . �5V   &   ��  �� 
TargetName$ txtClose��6-    �� Property � �� �� Value
 �  ��6Y   5W   #   P� 5X   "   $ stackAttachment��6*    �@J�IsMouseOver . . �5Y   &   �� $ stackAttachment��6-   # [ 6`    � ���� 5Z   &   $ txtFilename��6-    � ��
 �����6\   5]   #   5_      5d      5e      5f      �� 5g   
   $��3��6   $��2��6"   $��15,0,0,0q�66   $��Center=�6H   .+�5h      ��  d� 	IsChecked$
 TrueY�6   $(��"Send the Information Through Email��6(   5i      �� 5j   
   $��4��6   $��2��6"   $��0,0,20,0q�66   $��Right=�6H   .+�5k      �� $��25��6   $��60��6!   ��5l      �� 5m      $��Center=�6    $	��0,3q�6;   $��Submit��6H   5o      5p      5q      5r      