   M S B A M L   `   `   `  ����L  HSalaryApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:SalaryApplication.UISalaryApplication.UI  5   	   "    SalaryApplication.UI.NewComp   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:SalaryApplication.UI     5   	     � Title$!  Новая компания��5   	   $	��300��6    $��548.361��6-    � WindowStartupLocation$ CenterScreen=�6=   .��5	      � .+�5
   
   �� -   5         ��Name$ label��5
      $'��!Название компании��6   $
��Left=�6;   $��	10,10,0,0q�6V   $	��Top=�6i   �� 5   
   -   5         ��Name$ tbNameOfNewComp��5      $
��Left=�6+   $��23��6F   $��
161,13,0,0q�6R    �� TextWrapping$
 Wrap=�6f   $	��Top=�6z   $	��120��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgListOfCompanies��5      $
��Left=�6.   $��
301,13,0,0q�6I   $	��Top=�6]   $	��215��6u   $	��220��6�   �� 5   
   -   5        $ label1��5      $8��2Зарегистрировано компаний:��6    $
��Left=�6E   $��301,228,0,0q�6`   $	��Top=�6u   �� 5   
   -   5        $ lblCountOfCompanies��5      $��?��6-   $
��Left=�69   $��495,228,0,0q�6T   $	��Top=�6i   �� 5   
   -   5         ��Name$ btAddNewComp��5      $��Добавить��6'   $
��Left=�6:   $��
206,49,0,0q�6U   $	��Top=�6i   $��75��6�   6�   �� 5   
   -   5        $ btCancel��5      $��Отмена��6#   $
��Left=�64   $��
206,74,0,0q�6O   $	��Top=�6c   $��75��6{   6�   5      5      