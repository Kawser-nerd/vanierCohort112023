   M S B A M L   `   `   `  ����I  EsqlVanCohort11, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:sqlVanCohort11sqlVanCohort11  5   	       sqlVanCohort11.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:sqlVanCohort11     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � $	��NaN��6   $��	0,0,0,-22q�6   .+�5
   
   �� -   5         ��Name$ Canvas1��5
      $	��NaN��6"   $��	0,0,0,351q�6/   ���	#FFADD3EF.+�5      �� -   5         ��Name$ 	SearchBtn��5      $��Search��6(    �� Left$	 690��69   
 �� Top$ 21��6K   $��27��6[   $��63��6g   $��16(�6r    J� RenderTransformOrigin$ 0.5,0.5&�6�   $
��Left=�6�   $��Center=�6�   z�5      V� 5      .~�5      �� �� 5       �� AngleY$ 0Q�6(   �� 5      T� 5       T� Y$ 0Q�6-   5      5      5      �� 5   
   -   5         ��Name$ 	studentID��5      $
��Left=�6%   $��
498,24,0,0q�6@   	 �� TextWrapping$
	 Wrap=�6T   $��	Insert ID��6h   $	��Top=�6y   $	��153��6�   $��24��6�   $��16(�6�   �� 5   
   -   5        
 ��Name$
 label��5      $#��Vanier Cohort11 Students DB
��6   $
��Left=�6O   $��	44,20,0,0q�6j   $	��Top=�6}   $��16(�6�   $��32��6�   �� 5   
   -   5        $ InsertID��5      $
��Left=�6$   $��242,129,0,0q�6?   $
	 Wrap=�6T   $��	Insert ID��6h   $	��Top=�6y   $	��148��6�   $��16(�6�   �� 5   
   -   5        $ InsertLName��5      $
��Left=�6'   $��242,167,0,0q�6B   $
	 Wrap=�6W   $��Insert L. Name��6k   $	��Top=�6�   $	��148��6�   $��16(�6�   �� 5   
   -   5        $ InsertFName��5      $
��Left=�6'   $��242,208,0,0q�6B   $
	 Wrap=�6W   $��Insert F. Name��6k   $	��Top=�6�   $	��148��6�   $��16(�6�   �� 5   
   -   5        $ insertEmail��5      $
��Left=�6'   $��242,244,0,0q�6B   $
	 Wrap=�6W   $��Insert Email Add��6k   $	��Top=�6�   $	��148��6�   $��16(�6�   �� 5   
   -	   5        $
 label1��5      $��
Student ID��6    $
��Left=�65   $��118,125,0,0q�6P   $	��Top=�6e   $��16(�6}   �� 5   
   -
   5        $
 label2��5      $��	Last Name��6    $
��Left=�64   $��118,163,0,0q�6O   $	��Top=�6d   $��16(�6|   �� 5   
   -   5        $
 label2_Copy��5      $��
First Name��6%   $
��Left=�6:   $��118,204,0,0q�6U   $	��Top=�6j   $��16(�6�   �� 5   
   -   5        $
 label2_Copy1��5      $��Email��6&   $
��Left=�66   $��118,240,0,0q�6Q   $	��Top=�6f   $��16(�6~   �� 5    
   -   5        $ 	InsertSQL��5       $��Insert��6$   $
��Left=�65   $��472,118,0,0q�6P   $	��Top=�6e   $��40��6}   $	��124��6�   $��16(�6�   6�   �� 5!   
   -   5        $ 	DeleteSQL��5!      $��Delete��6$   $
��Left=�65   $��472,171,0,0q�6P   $	��Top=�6e   $��40��6}   $	��124��6�   $��16(�6�   ���	#FFEEC3C36�   �� 5"   
   -   5        $ 	UpdateSQL��5"      $��Update��6$   $
��Left=�65   $��472,224,0,0q�6P   $	��Top=�6e   $��40��6}   $	��124��6�   $��16(�6�   ���	#FF0AA1A66�   �� 5#   
   -   5        $ 	SelectSQL��5#      $
��Show��6$   $
��Left=�63   $��628,171,0,0q�6N   $	��Top=�6c   $��40��6{   $	��124��6�   $��16(�6�   ���	#FFD3F5F66�   &   System.Windows.Controls.DataGrid  5$   
   -   5          Name$ dataGrid��5$      $	��NaN��6&   $��44,298,66,40q�63   $	��NaN��6I   5&      5'      