using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TechnologyManager : MonoBehaviour {

	private double[] prices = {40e+3, 52.5e+3, 125e+3, 200e+3, 450e+3, 567e+3,
								1.2e+6, 1.8e+6, 5e+6, 8.32e+6, 13.1e+6, 41.6e+6, 68e+6,156e+6, 400e+6, 624e+6, 777e+6,
								1.86e+9, 2e+9, 3.2e+9, 4.3e+9, 5.4e+9, 6.24e+9, 20.3e+9, 55e+9, 84e+9, 222e+9, 249e+9, 689e+9, 850e+9, 950e+9, 960e+9,
								2e+12, 2.64e+12, 4.99e+12, 8e+12, 15e+12, 17.6e+12, 25e+12, 50e+12, 75e+12, 100e+12, 250e+12, 330e+12, 343e+12, 499e+12, 500e+12, 750e+12,
								2e+15, 3.7e+15, 5e+15, 10e+15, 15.4e+15, 40e+15, 160e+15, 247e+15, 694e+15, 778e+15, 800e+15,
								3e+18, 23e+18, 31.2e+18, 163e+18, 880e+18,
								1.41e+21, 3.7e+21, 4.1e+21, 34.3e+21, 63.2e+21, 69e+21, 96e+21, 177e+21, 222e+21, 274e+21, 631e+21,
								4e+24, 4.2e+24, 4.81e+24, 5e+24, 7.2e+24, 100e+24, 230e+24, 365e+24, 700e+24,
								1.51e+27, 4e+27, 9e+27, 11e+27, 27.8e+27, 75e+27, 220e+27, 318e+27, 440e+27, 660e+27, 880e+27,
								2e+30, 2.11e+30, 4.1e+30, 8.2e+30, 66.7e+30, 92e+30, 130e+30, 160e+30, 400e+30, 750e+30, 941e+30,
								14e+33, 15e+33, 20.2e+33, 25e+33, 45e+33, 90e+33, 500e+33,
								1.2e+36, 2.4e+36, 2.55e+36, 2.94e+36, 4.8e+36, 9.6e+36, 19.8e+36, 39.6e+36, 321e+36, 618e+36, 792e+36,
								1.58e+39, 3.17e+39, 6.34e+39, 12.7e+39, 40.4e+39, 100e+39, 130e+39, 200e+39, 300e+39, 500e+39, 600e+39, 700e+39, 800e+39, 900e+39,
								2.4e+42, 4.2e+42, 4.7e+42, 5.09e+42, 7.4e+42, 27.2e+42, 131e+42, 262e+42, 393e+42,
								1.8e+45, 2.8e+45, 5.72e+45, 6.5e+45, 9.3e+45, 20e+45, 30e+45, 40e+45, 200e+45, 300e+45, 400e+45, 635e+45,
								1.2e+48, 2e+48, 2e+48, 13.3e+48, 25.5e+48, 37.7e+48, 49.9e+48, 85e+48, 224e+48, 252e+48, 500e+48,
								1.5e+51, 3.5e+51, 6.5e+51, 17e+51, 19e+51, 53e+51, 63e+51, 79.1e+51, 577e+51,
								1.23e+54, 3.45e+54, 5.67e+54, 7.89e+54, 11.1e+54, 27.9e+54, 32.1e+54, 54.3e+54, 57.7e+54, 76.5e+54, 250e+54, 750e+54, 950e+54,
								2e+57, 2.34e+57, 4e+57, 7e+57, 11.1e+57, 49.9e+57, 50.1e+57, 100e+57, 491e+57,
								1e+60, 4.42e+60, 10e+60, 22.2e+60, 33.3e+60, 44.4e+60, 55.5e+60, 66.6e+60, 77.7e+60, 88.8e+60, 103e+60,
								1.76e+63, 2e+63, 3.8e+63, 7.9e+63, 21.6e+63, 27.9e+63, 97.2e+63, 268e+63, 420e+63, 700e+63, 840e+63,
								1.65e+66, 3.65e+66, 4.55e+66, 6.65e+66, 8.65e+66, 36e+66, 64e+66, 97e+66, 233e+66, 279e+66, 544e+66, 750e+66, 954e+66,
								2.99e+69, 4.99e+69, 8.99e+69, 9.99e+69, 52.00e+69, 171.00e+69, 200.00e+69, 225.00e+69, 369.00e+69, 500.00e+69, 950.00e+69,
								1.31e+72, 3.30e+72, 6.80e+72, 31.00e+72, 42.10e+72, 77.70e+72, 182.00e+72, 186.00e+72, 200.00e+72, 310.00e+72, 390.00e+72, 430.00e+72, 540.00e+72,
								8.84e+75, 9.30e+75, 68.90e+75, 85.00e+75, 91.10e+75, 147.00e+75, 550.00e+75,
								1.70e+78, 1.86e+78, 2.50e+78, 2.60e+78, 2.70e+78, 2.90e+78, 15.00e+78, 50.00e+78, 100.00e+78, 118.00e+78, 200.00e+78, 390.00e+78, 500.00e+78,
								1.00e+81, 2.00e+81, 5.00e+81, 10.00e+81, 20.00e+81, 50.00e+81, 81.90e+81, 95.60e+81, 100.00e+81, 200.00e+81, 300.00e+81,
								4.00e+84, 5.00e+84, 6.00e+84, 7.00e+84, 8.00e+84, 9.00e+84, 10.00e+84, 17.20e+84, 27.00e+84, 127.00e+84, 200.00e+84,
								1.50e+87, 3.61e+87, 8.00e+87, 40.00e+87, 77.00e+87, 168.00e+87, 330.00e+87, 520.00e+87, 758.00e+87, 810.00e+87,
								2.70e+90, 5.95e+90, 16.50e+90, 49.50e+90, 159.00e+90, 223.00e+90, 378.00e+90, 732.00e+90, 800.00e+90,
								3.24e+93, 9.30e+93, 26.00e+93, 33.40e+93, 53.00e+93, 87.00e+93, 100.00e+93, 295.00e+93,
								1.00e+96, 7.02e+96, 10.00e+96, 16.00e+96, 45.00e+96, 77.00e+96, 284.00e+96, 391.00e+96, 529.00e+96,
								1.47e+99, 1.49e+99, 2.49e+99, 6.49e+99, 24.00e+99, 38.00e+99, 74.00e+99, 158.00e+99, 310.00e+99, 528.00e+99, 770.00e+99,
								1.80e+102, 5.00e+102, 6.00e+102, 7.00e+102, 8.00e+102, 65.00e+102, 400.00e+102, 500.00e+102, 713.00e+102,
								1.50e+105, 2.75e+105, 7.23e+105, 13.70e+105, 34.40e+105, 45.50e+105, 70.00e+105, 300.00e+105, 810.00e+105, 963.00e+105,
								1.58e+108, 2.87e+108, 7.50e+108, 10.00e+108, 20.00e+108, 80.00e+108, 200.00e+108, 602.00e+108, 800.00e+108,
								1.30e+111, 2.10e+111, 3.20e+111, 4.30e+111, 5.40e+111, 60.00e+111, 126.00e+111, 145.00e+111, 777.00e+111, 797.00e+111,
								3.50e+114, 4.11e+114, 5.66e+114, 23.90e+114, 26.60e+114, 98.80e+114, 101.00e+114, 390.00e+114, 795.00e+114,
								3.85e+117, 5.58e+117, 6.78e+117, 8.20e+117, 24.60e+117, 30.00e+117, 80.00e+117, 690.00e+117,
								1.17e+120, 1.88e+120, 5.75e+120, 23.50e+120, 82.00e+120, 107.00e+120, 246.00e+120, 450.00e+120, 500.00e+120,
								4.70e+123, 7.40e+123, 17.50e+123, 51.60e+123, 82.00e+123, 150.00e+123, 350.00e+123, 466.00e+123, 550.00e+123,
								2.50e+126, 4.50e+126, 10.80e+126, 13.00e+126, 58.00e+126, 87.00e+126, 400.00e+126, 500.00e+126,
								2.02e+129, 2.28e+129, 4.00e+129, 5.00e+129, 20.00e+129, 85.00e+129, 180.00e+129, 478.00e+129, 630.00e+129, 880.00e+129,
								1.75e+132, 4.00e+132, 8.50e+132, 8.81e+132, 40.00e+132, 80.00e+132, 100.00e+132, 310.00e+132, 400.00e+132, 510.00e+132,
								5.10e+135, 21.10e+135, 51.10e+135, 82.00e+135, 310.00e+135, 471.00e+135, 610.00e+135, 870.00e+135,
								1.79e+138, 3.66e+138, 4.43e+138, 8.90e+138, 70.00e+138, 80.00e+138, 90.00e+138, 100.00e+138, 600.00e+138, 930.00e+138,
								1.35e+141, 3.97e+141, 9.97e+141, 25.20e+141, 35.50e+141, 60.00e+141, 195.00e+141, 198.00e+141, 597.00e+141,
								1.65e+144, 7.00e+144, 17.30e+144, 41.00e+144, 49.00e+144, 220.00e+144, 720.00e+144,
								1.35e+147, 2.70e+147, 8.10e+147, 8.61e+147, 9.10e+147, 21.00e+147, 59.50e+147, 120.00e+147, 240.00e+147, 960.00e+147,
								1.81e+150, 4.30e+150, 5.40e+150, 15.00e+150, 60.00e+150, 72.20e+150, 240.00e+150, 380.00e+150, 900.00e+150,
								2.50e+153, 3.00e+153, 60.00e+153, 79.80e+153, 130.00e+153, 390.00e+153,
								1.17e+156, 3.51e+156, 3.86e+156, 14.00e+156, 16.80e+156, 70.00e+156, 350.00e+156,
								1.05e+159, 3.52e+159, 5.25e+159, 17.70e+159, 37.30e+159, 75.00e+159, 545.00e+159, 739.00e+159,
								3.13e+162, 9.13e+162, 33.00e+162, 44.00e+162, 55.00e+162, 66.00e+162, 155.00e+162, 270.00e+162, 810.00e+162,
								2.42e+165, 12.50e+165, 32.60e+165, 37.50e+165, 112.00e+165, 575.00e+165,
								2.00e+168, 4.50e+168, 6.84e+168, 19.90e+168, 58.80e+168, 73.30e+168, 400.00e+168, 500.00e+168,
								1.44e+171, 6.00e+171, 18.00e+171, 79.00e+171, 290.00e+171, 302.00e+171,
								1.00e+174, 2.10e+174, 4.80e+174, 14.80e+174, 63.40e+174, 72.00e+174, 480.00e+174,
								1.55e+177, 6.00e+177, 7.00e+177, 13.30e+177, 18.00e+177, 54.00e+177, 177.00e+177, 435.00e+177,
								2.79e+180, 3.00e+180, 9.00e+180, 25.00e+180, 100.00e+180, 587.00e+180,
								1.00e+183, 2.00e+183, 4.00e+183, 18.00e+183, 65.00e+183, 123.00e+183, 325.00e+183, 580.00e+183,
								2.55e+186, 5.55e+186, 15.50e+186, 25.90e+186, 133.00e+186, 390.00e+186, 500.00e+186, 600.00e+186,
								2.20e+189, 5.43e+189, 8.80e+189, 20.00e+189, 85.00e+189, 100.00e+189, 200.00e+189, 500.00e+189,
								1.14e+192, 4.00e+192, 20.00e+192, 30.00e+192, 40.00e+192, 80.00e+192, 180.00e+192, 240.00e+192, 490.00e+192,
								1.47e+195, 5.88e+195, 17.60e+195, 50.30e+195, 70.60e+195, 212.00e+195, 847.00e+195,
								2.54e+198, 10.20e+198, 10.60e+198, 30.50e+198, 122.00e+198, 238.00e+198, 930.00e+198,
								2.70e+201, 4.80e+201, 5.60e+201, 37.50e+201, 177.00e+201, 435.00e+201, 605.00e+201,
								2.81e+204, 4.31e+204, 11.50e+204, 50.70e+204, 108.00e+204, 411.00e+204, 486.00e+204,
								3.29e+207, 3.76e+207, 16.80e+207, 82.30e+207, 181.00e+207, 780.00e+207, 886.00e+207,
								1.43e+210, 1.80e+210, 4.74e+210, 5.70e+210, 8.37e+210, 36.00e+210, 41.80e+210, 84.50e+210, 96.60e+210, 125.00e+210, 195.00e+210, 254.00e+210, 976.00e+210,
								1.59e+213, 2.90e+213, 5.20e+213, 5.81e+213, 5.98e+213, 9.59e+213, 26.00e+213, 38.90e+213, 50.00e+213, 95.20e+213, 137.00e+213, 371.00e+213, 773.00e+213,
								1.42e+216, 1.69e+216, 2.86e+216, 3.63e+216, 7.64e+216, 7.65e+216, 19.40e+216, 150.00e+216, 197.00e+216, 233.00e+216, 457.00e+216, 611.00e+216, 631.00e+216,
								1.08e+219, 2.94e+219, 3.86e+219, 4.78e+219, 6.23e+219, 22.10e+219, 26.60e+219, 65.90e+219, 105.00e+219, 133.00e+219, 406.00e+219, 842.00e+219,
								32.00e+222, 80.00e+222, 278.00e+222, 845.00e+222,
								3.59e+225, 14.70e+225, 83.00e+225, 198.00e+225, 601.00e+225,
								2.70e+228, 5.80e+228, 6.24e+228, 88.20e+228, 979.00e+228,
								2.00e+231, 4.64e+231, 33.10e+231, 79.90e+231, 351.00e+231, 723.00e+231,
								3.73e+234, 5.72e+234, 16.70e+234, 58.80e+234, 120.00e+234, 271.00e+234, 501.00e+234,
								3.64e+237, 5.95e+237, 9.99e+237, 42.70e+237, 80.00e+237, 311.00e+237, 560.00e+237,
								4.97e+240, 7.19e+240, 17.30e+240, 92.50e+240, 141.00e+240, 873.00e+240, 905.00e+240, 962.00e+240,
								4.26e+243, 4.49e+243, 21.40e+243, 63.10e+243, 250.00e+243, 370.00e+243};
								
	private int[] types = {0, 1, 0, 2, 0, 1, 3, 0, 4, 1, 0, 1, 0, 3, 5, 1, 0, 0, 0, 0, 0, 
							4, 1, 3, 0, 5, 2, 1, 0, 0, 0, 0, 0, 3, 1, 4, 1, 5, 0, 0, 0, 0, 
							0, 4, 3, 1, 0, 0, 0, 5, 0, 4, 6, 0, 0, 2, 6, 5, 0, 0, 4, 6, 5, 
							0, 6, 0, 0, 5, 6, 4, 4, 0, 0, 2, 0, 0, 0, 6, 0, 5, 0, 4, 6, 0, 
							5, 0, 4, 0, 6, 0, 0, 5, 0, 0, 4, 0, 6, 0, 0, 5, 0, 0, 6, 0, 4, 
							0, 5, 0, 6, 0, 0, 0, 0, 4, 0, 6, 5, 0, 0, 0, 0, 6, 5, 0, 0, 4, 
							0, 0, 6, 0, 5, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 6, 0, 5, 0, 0, 0, 
							6, 0, 5, 0, 0, 4, 0, 0, 0, 0, 0, 6, 5, 0, 0, 0, 4, 0, 0, 0, 6, 
							5, 0, 0, 4, 0, 0, 0, 5, 0, 6, 4, 0, 0, 0, 0, 5, 6, 0, 0, 4, 0, 
							0, 0, 0, 0, 5, 0, 0, 6, 0, 0, 4, 5, 4, 6, 4, 0, 0, 0, 0, 0, 0, 
							0, 5, 6, 0, 0, 0, 5, 0, 4, 0, 0, 6, 0, 0, 0, 5, 0, 0, 0, 0, 4, 
							0, 6, 0, 4, 5, 0, 0, 0, 0, 0, 0, 5, 6, 0, 0, 0, 0, 0, 0, 0, 5, 
							0, 6, 0, 0, 2, 0, 0, 0, 5, 0, 4, 0, 0, 6, 0, 0, 5, 0, 4, 0, 0, 
							0, 0, 0, 6, 0, 5, 0, 0, 4, 0, 0, 0, 0, 5, 6, 0, 4, 0, 0, 0, 0, 
							0, 0, 0, 0, 5, 2, 6, 0, 0, 5, 4, 0, 0, 6, 0, 0, 5, 4, 0, 0, 0, 
							0, 5, 6, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 6, 4, 5, 0, 0, 0, 0, 0, 
							6, 0, 5, 0, 0, 0, 4, 0, 0, 0, 5, 6, 0, 0, 0, 0, 0, 0, 5, 0, 0, 
							6, 0, 0, 0, 5, 4, 0, 0, 0, 4, 6, 0, 5, 0, 0, 0, 0, 0, 5, 0, 6, 
							0, 0, 0, 0, 0, 5, 0, 0, 0, 4, 0, 6, 0, 5, 0, 0, 0, 0, 0, 5, 0, 
							0, 6, 4, 0, 0, 5, 0, 4, 0, 0, 6, 5, 0, 0, 0, 0, 0, 5, 0, 0, 4, 
							6, 0, 0, 0, 5, 0, 0, 0, 0, 0, 6, 5, 4, 0, 0, 0, 0, 5, 4, 4, 0, 
							0, 0, 6, 0, 0, 5, 0, 0, 0, 0, 5, 0, 4, 0, 6, 0, 0, 0, 0, 5, 0, 
							0, 0, 0, 0, 0, 5, 0, 0, 4, 6, 0, 0, 5, 0, 0, 0, 0, 0, 5, 4, 0, 
							0, 6, 0, 0, 5, 0, 0, 0, 4, 0, 0, 5, 0, 0, 0, 0, 6, 0, 5, 4, 0, 
							0, 0, 5, 0, 0, 0, 0, 6, 0, 5, 0, 0, 0, 5, 0, 4, 0, 0, 0, 5, 0, 
							4, 0, 0, 0, 0, 5, 0, 0, 0, 0, 5, 4, 0, 0, 0, 0, 5, 0, 0, 0, 0, 
							0, 5, 0, 4, 4, 0, 5, 0, 0, 0, 0, 5, 4, 0, 0, 0, 0, 5, 0, 0, 0, 
							0, 5, 4, 0, 0, 0, 5, 0, 0, 0, 0, 0, 5, 4, 0, 0, 0, 0, 5, 0, 0, 
							0, 0, 0, 5, 0, 0, 4, 0, 0, 0, 5, 4, 0, 0, 0, 0, 0, 5, 0, 0, 4, 
							4, 5, 0, 0, 0, 4, 0, 5, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 4, 0, 0, 
							0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 
							0, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 
							0, 0, 0, 4, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 
							0, 0, 4, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 4, 
							0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 4, 0, 0, 
							0, 0, 0, 0, 0, 0};
	
	private float[] bonus = {5f, 0f, 3f, 6f, 4f, 0f, 0f, 5f, 3f, 0f, 4f, 0f, 4f, 0f, 0.12f, 
							0f, 5f, 4f, 6f, 5f, 5f, 4f, 0f, 0f, 6f, 0.08f, 5f, 0f, 5f, 4f, 
							5f, 6f, 3f, 0f, 0f, 2f, 0f, 0.01f, 8f, 6f, 6f, 2f, 6f, 6f, 0f, 
							0f, 3f, 4f, 6f, 0.08f, 3f, 3f, 0f, 2f, 3f, 4f, 0f, 0.12f, 3f, 
							2f, 2f, 0f, 0.08f, 5f, 0f, 4f, 4f, 0.01f, 0f, 3f, 2f, 4f, 4f, 
							3f, 4f, 4f, 4f, 0f, 4f, 0.08f, 4f, 2f, 0f, 4f, 0.12f, 4f, 5f, 
							3f, 0f, 3f, 3f, 0.12f, 3f, 3f, 3f, 3f, 0f, 3f, 3f, 0.12f, 15f, 
							4f, 0f, 4f, 5f, 4f, 0.08f, 4f, 0f, 4f, 4f, 3f, 2f, 2f, 2f, 0f, 
							0.06f, 5f, 15f, 5f, 5f, 0f, 0.08f, 4f, 5f, 4f, 4f, 4f, 0f, 4f, 
							0.12f, 4f, 3f, 3f, 4f, 5f, 9f, 3f, 3f, 3f, 3f, 0f, 3f, 0.08f, 
							3f, 3f, 3.5f, 0f, 3.5f, 0.06f, 3.5f, 10.5f, 2.5f, 3.5f, 3.5f, 
							3.5f, 3.5f, 3.5f, 0f, 0.08f, 3.5f, 5f, 5f, 3f, 5f, 5f, 15f, 0f, 
							0.12f, 5f, 5f, 3f, 5f, 5f, 5f, 0.12f, 8f, 0f, 3f, 8f, 7f, 6f, 5f, 
							0.12f, 0f, 12f, 6f, 3f, 6f, 7f, 5f, 3f, 3f, 0.08f, 3f, 3f, 0f, 3f, 
							3f, 2f, 0.06f, 3f, 0f, 2f, 9f, 3f, 3f, 3f, 2f, 3f, 2f, 0.08f, 0f, 
							3f, 4f, 4f, 0.12f, 4f, 4f, 12f, 3f, 0f, 4f, 7f, 7f, 0.08f, 7f, 7f, 
							7f, 7f, 3f, 7f, 0f, 7f, 2f, 0.06f, 21f, 7f, 13f, 14f, 13f, 12f, 
							0.08f, 0f, 13f, 15f, 14f, 13f, 14f, 45f, 5f, 0.12f, 6f, 0f, 7f, 
							5f, 4f, 28f, 2f, 7f, 0.12f, 3f, 4f, 4f, 5f, 0f, 2f, 2f, 0.12f, 3f, 
							5f, 8f, 3f, 7f, 5f, 2f, 0f, 7f, 0.08f, 7f, 3f, 2f, 3f, 12f, 3f, 3f, 
							0.06f, 0f, 3f, 3f, 3f, 3f, 3f, 3f, 5.2f, 21f, 5.2f, 5.2f, 0.08f, 
							3f, 0f, 5.2f, 5.2f, 0.12f, 3f, 5.2f, 5.2f, 0f, 5.2f, 5.2f, 0.08f,
							5f, 30f, 7.77f, 7.77f, 7.77f, 0.06f, 0f, 7.77f, 7.77f, 7.77f, 
							7.77f, 7.77f, 7.77f, 0.08f, 4f, 4f, 4f, 0f, 5f, 0.12f, 4f, 4f, 
							4f, 4f, 4f, 0f, 4f, 0.12f, 16f, 6.666f, 6.666f, 3f, 3.333f, 
							6.666f, 3.333f, 0.12f, 0f, 6.666f, 6.666f, 3.333f, 6.664f, 
							3.333f, 7f, 0.08f, 7f, 7f, 0f, 7f, 7f, 7f, 0.06f, 5f, 7f, 28f, 
							7f, 2f, 0f, 7f, 0.08f, 11f, 11f, 11f, 11f, 11f, 0.12f, 11f, 0f, 
							44f, 11f, 11f, 11f, 10f, 0.08f, 10f, 10f, 10f, 8f, 10f, 0f, 40f, 
							0.06f, 10f, 10f, 10f, 10f, 3.1416f, 0.08f, 3.1416f, 3.1416f, 
							0f, 2f, 3.1416f, 3.1416f, 0.12f, 3.1416f, 3f, 3.1416f, 3.1416f, 
							0f, 0.12f, 3.1416f, 3.1416f, 2.95f, 2.95f, 2.95f, 0.12f, 2.95f, 
							2.95f, 4f, 0f, 2.95f, 2.95f, 2.95f, 0.08f, 2.95f, 15f, 8f, 8f, 8f, 0f, 
							0.06f, 5f, 8f, 8f, 8f, 8f, 0.08f, 2f, 6f, 8f, 40f, 8f, 0f, 3f, 3f, 0.12f, 
							3f, 3f, 3f, 3f, 0.08f, 3f, 2f, 15f, 0f, 3f, 3f, 15f, 13f, 0.06f, 12f, 15f, 
							6f, 13f, 65f, 13f, 0.08f, 12f, 11f, 5f, 0f, 4f, 4f, 0.12f, 4f, 4f, 4f, 
							20f, 4f, 0.12f, 3f, 4f, 4f, 0f, 4f, 5f, 0.12f, 5f, 5f, 5f, 4f, 25f, 5f, 
							0.08f, 5f, 5f, 5f, 5f, 0f, 6f, 0.06f, 2f, 6f, 6f, 30f, 0.08f, 6f, 6f, 
							6f, 6f, 0f, 6f, 0.12f, 6f, 12f, 12f, 0.08f, 60f, 2f, 12f, 12f, 12f, 
							0.06f, 12f, 4f, 12f, 12f, 12f, 6f, 0.08f, 30f, 6f, 6f, 6f, 0.12f, 2f, 
							6f, 6f, 6f, 6f, 0.12f, 6f, 25f, 5f, 5f, 5f, 0.12f, 5f, 4f, 3f, 5f, 0.08f, 
							5f, 5f, 5f, 5f, 0.06f, 4f, 8f, 8f, 24f, 8f, 0.08f, 8f, 8f, 8f, 8f, 0.12f, 
							2f, 8f, 8f, 7f, 0.08f, 7f, 7f, 7f, 7f, 21f, 0.06f, 7f, 7f, 7f, 7f, 7f, 
							0.08f, 5f, 5f, 5f, 5f, 5f, 0.12f, 5f, 5f, 2f, 5f, 15f, 5f, 0.12f, 4f, 
							9f, 27f, 9f, 9f, 9f, 0.12f, 9f, 9f, 2f, 4f, 0.08f, 9f, 9f, 9f, 2f, 13f, 
							0.06f, 13f, 13f, 13f, 39f, 5f, 13f, 13f, 13f, 13f, 13f, 3f, 6f, 6f, 6f, 
							6f, 6f, 6f, 4f, 6f, 18f, 6f, 6f, 15f, 5f, 5f, 5f, 5f, 5f, 5f, 3f, 3f, 5f, 5f, 
							4.5f, 5f, 4.5f, 4.5f, 15f, 3f, 4f, 2f, 4.5f, 2f, 4.5f, 2f, 6f, 4f, 2f, 
							4.5f, 4.5f, 2f, 2f, 4.5f, 2f, 4.5f, 2f, 2f, 13.5f, 4f, 3f, 4f, 3f, 9f, 
							3f, 9f, 3f, 9f, 9f, 3f, 3f, 9f, 9f, 5f, 3f, 9f, 9f, 9f, 9f, 2f, 9f, 5f, 5f, 
							5f, 4f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 7f, 7f, 4f, 7f, 7f, 4f, 7f, 7f, 7f, 7f, 
							7f, 7f, 5f, 5f, 5f, 5f, 5f, 5f, 3f, 5f, 5f, 5f, 5f, 8f, 3f, 8f, 8f, 8f, 8f, 8f, 8f, 8f, 8};
							
	private int[] modOrder = {1, 0, 2, 0, 3, 0, 0, 4, 0, 0, 1, 0, 2, 0, 3 , 0, 3, 4, 5, 6, 
							1, 0, 0, 0, 2, 4 , 0, 0, 3, 4, 5, 6, 7, 0, 0, 0, 0, 5 , 1, 
							2, 3, 4, 5, 0, 0, 0, 6, 7, 8, 6 , 9, 0, 0, 7, 8, 0, 0, 7 , 
							9, 10, 0, 0, 6 , 1, 0, 2, 3, 5 , 0, 0, 0, 4, 5, 0, 6, 7, 8, 
							0, 9, 4 , 10, 0, 0, 1, 3 , 2, 0, 3, 0, 4, 5, 7 , 6, 7, 0, 8, 
							0, 9, 10, 3 , 1, 2, 0, 4, 0, 3, 4 , 5, 0, 6, 7, 8, 9, 0, 10, 
							0, 5 , 1, 2, 3, 4, 0, 6 , 5, 6, 0, 7, 8, 0, 9, 7 , 10, 1, 2, 
							0, 0, 3, 4, 5, 6, 7, 0, 8, 6 , 9, 10, 1, 0, 2, 5 , 3, 4, 0, 
							5, 6, 7, 8, 9, 0, 4 , 10, 1, 2, 0, 3, 4, 5, 0, 3 , 6, 7, 0, 
							8, 9, 10, 7 , 1, 0, 0, 2, 3, 4, 5, 3 , 0, 6, 7, 0, 8, 9, 10, 
							1, 2, 4 , 3, 4, 0, 5, 6, 0, 5 , 0, 0, 0, 7, 8, 9, 10, 1, 2, 
							3, 6 , 0, 4, 5, 6, 7 , 7, 0, 8, 9, 0, 10, 1, 2, 6 , 3, 4, 5, 
							6, 0, 7, 0, 8, 0, 5 , 9, 10, 1, 2, 3, 4, 4 , 0, 5, 6, 7, 8, 
							9, 10, 1, 3 , 2, 0, 3, 4, 0, 5, 6, 7, 7 , 8, 0, 9, 10, 0, 1, 
							2, 3 , 3, 0, 4, 5, 6, 7, 8, 0, 9, 4 , 10, 1, 0, 2, 3, 4, 5, 
							5 , 0, 6, 0, 7, 8, 9, 10, 1, 2, 3, 4, 6 , 0, 0, 5, 6, 7 , 0, 
							7, 8, 0, 9, 10, 6 , 0, 1, 2, 3, 4, 5 , 0, 5, 6, 7, 8, 9, 10, 
							4 , 1, 2, 3, 0, 0, 3 , 4, 5, 6, 7, 8, 0, 9, 7 , 10, 1, 2, 0, 
							3, 4, 5, 3 , 0, 6, 7, 8, 9, 10, 1, 4 , 2, 3, 0, 4, 5, 6, 5 , 
							0, 7, 8, 9, 0, 0, 10, 6 , 1, 2, 3, 4, 5, 7 , 6, 0, 7, 8, 9, 
							10, 1, 6 , 2, 3, 4, 0, 5, 0, 6, 5 , 7, 8, 9, 10, 1, 4 , 2, 3, 
							0, 0, 4, 5, 3 , 6, 0, 7, 8, 0, 7 , 9, 10, 1, 2, 3, 3 , 4, 5, 
							0, 0, 6, 7, 8, 4 , 9, 10, 1, 2, 3, 0, 5 , 0, 4, 5, 6, 7, 6 , 
							0, 0, 8, 9, 10, 0, 1, 2, 7 , 3, 4, 5, 6, 6 , 7, 0, 8, 0, 9, 
							10, 1, 2, 5 , 3, 4, 5, 6, 7, 8, 4 , 9, 10, 0, 0, 1, 2, 3 , 3, 
							4, 5, 6, 7, 7 , 0, 8, 9, 0, 10, 1, 3 , 2, 3, 4, 0, 5, 6, 4 , 
							7, 8, 9, 10, 0, 1, 5 , 0, 2, 3, 4, 6 , 5, 6, 7, 8, 0, 9, 7 , 
							10, 1, 2, 6 , 3, 0, 4, 5, 6, 5 , 7, 0, 8, 9, 10, 1, 4 , 2, 3, 
							4, 5, 3 , 0, 6, 7, 8, 9, 7 , 10, 1, 2, 3, 4, 3 , 5, 0, 0, 6, 
							4 , 7, 8, 9, 10, 5 , 0, 1, 2, 3, 4, 6 , 5, 6, 7, 8, 7 , 0, 9, 
							10, 1, 6 , 2, 3, 4, 5, 6, 5 , 0, 7, 8, 9, 10, 4 , 1, 2, 3, 4, 
							5, 3 , 6, 7, 0, 8, 9, 10, 7 , 0, 1, 2, 3, 4, 5, 3 , 6, 7, 0, 
							0, 4 , 8, 9, 10, 0, 1, 5 , 2, 3, 4, 5, 0, 6, 7, 8, 9, 10, 0, 
							1, 2, 3, 4, 5, 6, 0, 7, 8, 9, 10, 1, 2, 3, 5, 0, 4, 6, 9, 10, 
							7, 9, 1, 8, 2, 3, 10, 0, 0, 2, 4, 1, 5, 3, 4, 0, 5, 6, 7, 6, 
							7, 8, 8, 9, 10, 9, 10, 0, 1, 0, 1, 1, 3, 2, 4, 4, 3, 5, 6, 7, 
							5, 0, 8, 6, 7, 8, 9, 0, 10, 1, 2, 3, 0, 4, 5, 7, 6, 8, 9, 10, 
							1, 2, 0, 3, 4, 0, 5, 6, 7, 8, 9, 10, 1, 2, 3, 4, 5, 6, 0, 7, 
							8, 9, 10, 1, 0, 2, 3, 4, 5, 6, 7, 8, 9};
							
	private string[] greenModules = {"Micro SD Module", "SD Module", "VMD Module", 
									"EVD Module", "UMD Module", 
									"HVD Module", "Archival Disc Module", "Hard Disc Module", 
									"Galatic Disc Module", "Antimatter Disc Module"};
	private string[] redModules = {"Dinamite Module", "C4 Module", "Power Module", "Energy Shield Module", 
									"Armor Module", "Enemy Sensor Module", "Ion Pulse Module", "Communication Module", 
									"Adamantium Armor Module", "Atomic Module"};
	private string[] blueModules = {"Scan Module", "Sonar Module", "Power Module", "Infrared Module", 
									"Speed Module", "Collision Detect Module", "Blue Laser Module", 
									"Termal Sensor Module", "Advanced Memory Module", "Atlas Module"};
	private string[] yellowModules = {"Combustion Propellant Module", "Nuclear Propellant Module", "Atomic Propellant Module", 
									"Hidrogen Propullant Module", "Electromagnetic Repulsion Module", "Ion Propellant Module", 
									"Comet Hitchhiker Module", "Solar Sails Module", "Black Hole Propellant Module", "Space Fold Module"};

	public int numberOfGreenTechDiscovery;
	public int numberOfBlueTechDiscovery;
	public int numberOfRedTechDiscovery;
	public int numberOfYellowTechDiscovery;

	public bool[] BuyedGreenTech = new bool[741];
	public bool[] BuyedBlueTech = new bool[741];
	public bool[] BuyedRedTech = new bool[741];
	public bool[] BuyedYellowTech = new bool[741];

	public bool isGreen;
	public bool isBlue;
	public bool isRed;
	public bool isYellow;

	//Tech Cards
	public GameObject greenTechCardPrefab;
	public GreenTechnologyManager greenTechnology;
	public GameObject blueTechCardPrefab;
	public BlueTechnologyManager blueTechnology;
	public GameObject redTechCardPrefab;
	public RedTechnologyManager redTechnology;
	public GameObject yellowTechCardPrefab;
	public YellowTechnologyManager yellowTechnology;

	public Text blueTechDisplay;
	public Text greenTechDisplay;
	public Text redTechDisplay;
	public Text yellowTechDisplay;

	//All controller array is 0 at 740
	public int index;

	public GameObject techContent;

	public GameObject resetCards;
	public bool greenTech;
	public bool blueTech;
	public bool redTech;
	public bool yellowTech;

	public int numberOfGreenCard;
	public int numberOfBlueCard;
	public int numberOfRedCard;
	public int numberOfYellowCard;
	SaveTechnology save;

	void OnApplicationPause () {
		SaveGame ();
	}

	void Awake () {
		LoadGame ();
	}

	// Use this for initialization
	void Start () {
		BuyedGreenTech = new bool[741];
    	BuyedBlueTech = new bool[741];
   		BuyedRedTech = new bool[741];
     	BuyedYellowTech = new bool[741];
		LoadGame ();
	}
	
	// Update is called once per frame
	void Update () {
		blueTechDisplay.text = "<b>Blue Technology Discovered</b>\n" + numberOfBlueTechDiscovery + "/741";
		greenTechDisplay.text = "<b>Green Technology Discovered</b>\n" + numberOfGreenTechDiscovery + "/741";
		redTechDisplay.text = "<b>Red Technology Discovered</b>\n" + numberOfRedTechDiscovery + "/741";
		yellowTechDisplay.text = "<b>Yellow Technology Discovered</b>\n" + numberOfYellowTechDiscovery + "/741";
	}

	public void MakeCards () {
		if (isGreen) {
			greenTech = true;
			blueTech = false;
			redTech = false;
			yellowTech = false;
			for (index = 0; index < numberOfGreenTechDiscovery; index++) {
				if (BuyedGreenTech [index] == false) {
					MakeGreenTechCard (types [index]);
				}
			}

		}

		if (isBlue) {
			blueTech = true;
			greenTech = false;
			redTech = false;
			yellowTech = false;
			for (index = 0; index < numberOfBlueTechDiscovery; index++) {
				if (BuyedBlueTech [index] == false) {
					MakeBlueTechCard (types [index]);
				}
			}

		}

		if (isRed) {
			redTech = true;
			blueTech = false;
			greenTech = false;
			yellowTech = false;
			for (index = 0; index < numberOfRedTechDiscovery; index++) {
				if (BuyedRedTech [index] == false) {
					MakeRedTechCard (types [index]);
				}
			}

		}

		if (isYellow) {
			yellowTech = true;
			redTech = false;
			blueTech = false;
			greenTech = false;
			for (index = 0; index < numberOfYellowTechDiscovery; index++) {
				if (BuyedYellowTech [index] == false) {
					MakeYellowTechCard (types [index]);
				}

			}

		}
	}

	public void MakeGreenTechCard (int type) {
		if (greenTech == true) {
			for (int i = 0; i < numberOfGreenTechDiscovery; i++) {
				resetCards = GameObject.Find ("Green Technology Card(Clone)");
				Destroy (resetCards);
			}
			//while (GameObject.Find ("Green Technology Card(Clone)") != null) {
			//	resetCards = GameObject.Find ("Green Technology Card(Clone)");
			//	Destroy (resetCards);
			//}
			greenTech = false;
			numberOfGreenCard = 0;
		}

			GameObject go;
			go = Instantiate (greenTechCardPrefab) as GameObject;
			go.transform.SetParent (transform);
			greenTechnology = (GreenTechnologyManager)go.GetComponent (typeof(GreenTechnologyManager));

			go.transform.SetParent (GameObject.Find ("TechContent").transform);
			RectTransform myRectTransform = go.transform.GetComponent<RectTransform> ();
			float myY = 160 + (310 * numberOfGreenCard);
			myRectTransform.localPosition = new Vector3 (361.5f, -myY, 0.0f);
			numberOfGreenCard++;

			switch (type) {
			case 0:
				greenTechnology.techName = "Tech Upgrade " + greenModules [(modOrder [index] - 1)];
				greenTechnology.techDescription = "Increased " + greenModules [(modOrder [index] - 1)] + " Data by x" + bonus [index];
				greenTechnology.mod = greenModules [(modOrder [index] - 1)];
				greenTechnology.cost = prices [index];
				greenTechnology.upgradeBonusScale = bonus [index];
				greenTechnology.moduleNumber = modOrder [index];
				greenTechnology.upgradeType = types [index];
				greenTechnology.index = index;
				break;
			case 1:
				greenTechnology.techName = "Tech Upgrade Green Probe Factory";
				greenTechnology.techDescription = "Automatically green probe fabrication +1";
				greenTechnology.cost = prices [index];
				greenTechnology.upgradeBonusScale = bonus [index];
				greenTechnology.moduleNumber = modOrder [index];
				greenTechnology.upgradeType = types [index];
				greenTechnology.index = index;
				break;
			case 2:
				greenTechnology.techName = "Tech Upgrade Green Probe Factory";
				greenTechnology.techDescription = "Automatically green probe fabrication +1";
				greenTechnology.cost = prices [index];
				greenTechnology.upgradeBonusScale = bonus [index];
				greenTechnology.moduleNumber = modOrder [index];
				greenTechnology.upgradeType = types [index];
				greenTechnology.index = index;
				break;
			case 3:
			//Unlock Green Skill Card Type
				greenTechnology.techName = "Upgrade Green Skills Levels";
				greenTechnology.techDescription = "Increased All Green Skill Level by 1";
				greenTechnology.cost = prices [index];
				greenTechnology.upgradeBonusScale = bonus [index];
				greenTechnology.moduleNumber = modOrder [index];
				greenTechnology.upgradeType = types [index];
				greenTechnology.index = index;
				break;
			case 4:
				greenTechnology.techName = "Tech Upgrade All Modules and Factory";
				greenTechnology.techDescription = "Increased All Green Modules Damage by x" + bonus [index] + " and Automatically green probe fabrication +1";
				greenTechnology.cost = prices [index];
				greenTechnology.upgradeBonusScale = bonus [index];
				greenTechnology.moduleNumber = modOrder [index];
				greenTechnology.upgradeType = types [index];
				greenTechnology.index = index;
				break;
			case 5:
				greenTechnology.techName = "Tech Upgrade " + greenModules [(modOrder [index] - 1)];
				greenTechnology.techDescription = "Reduce " + greenModules [(modOrder [index] - 1)] + " Cost to x" + bonus [index];
				greenTechnology.cost = prices [index];
				greenTechnology.upgradeBonusScale = bonus [index];
				greenTechnology.moduleNumber = modOrder [index];
				greenTechnology.upgradeType = types [index];
				greenTechnology.index = index;
				break;
			case 6:
			//Upgrade Green Skill Card Type
				greenTechnology.techName = "Upgrade Green Skills Levels";
				greenTechnology.techDescription = "Increased All Green Skill Level by 1";
				greenTechnology.cost = prices [index];
				greenTechnology.upgradeBonusScale = bonus [index];
				greenTechnology.moduleNumber = modOrder [index];
				greenTechnology.upgradeType = types [index];
				greenTechnology.index = index;
				break;
			}

	}

	public void MakeBlueTechCard (int type) {
		if (blueTech == true) {
			for (int i = 0; i < numberOfBlueTechDiscovery; i++) {
				resetCards = GameObject.Find ("Blue Technology Card(Clone)");
				Destroy (resetCards);
			}
			//while (GameObject.Find ("Blue Technology Card(Clone)")) {
			//	resetCards = GameObject.Find ("Blue Technology Card(Clone)");
			//	Destroy (resetCards);
			//}
			blueTech = false;
			numberOfBlueCard = 0;
		}

			GameObject go;
			go = Instantiate (blueTechCardPrefab) as GameObject;
			go.transform.SetParent (transform);
			blueTechnology = (BlueTechnologyManager)go.GetComponent (typeof(BlueTechnologyManager));

			go.transform.SetParent (GameObject.Find ("TechContent").transform);
			RectTransform myRectTransform = go.transform.GetComponent<RectTransform> ();
			float myY = 160 + (310 * numberOfBlueCard);
			myRectTransform.localPosition = new Vector3 (361.5f, -myY, 0.0f);
			numberOfBlueCard++;

			switch (type) {
			case 0:
				blueTechnology.techName = "Tech Upgrade " + blueModules [(modOrder [index] - 1)];
				blueTechnology.techDescription = "Increased " + blueModules [(modOrder [index] - 1)] + " Scanning by x" + bonus [index];
				blueTechnology.mod = blueModules [(modOrder [index] - 1)];
				blueTechnology.cost = prices [index];
				blueTechnology.upgradeBonusScale = bonus [index];
				blueTechnology.moduleNumber = modOrder [index];
				blueTechnology.upgradeType = types [index];
				blueTechnology.index = index;
				break;
			case 1:
				blueTechnology.techName = "Tech Upgrade Blue Probe Factory";
				blueTechnology.techDescription = "Automatically blue probe fabrication +1";
				blueTechnology.cost = prices [index];
				blueTechnology.upgradeBonusScale = bonus [index];
				blueTechnology.moduleNumber = modOrder [index];
				blueTechnology.upgradeType = types [index];
				blueTechnology.index = index;
				break;
			case 2:
				blueTechnology.techName = "Tech Upgrade Blue Probe Factory";
				blueTechnology.techDescription = "Automatically blue probe fabrication +1";
				blueTechnology.cost = prices [index];
				blueTechnology.upgradeBonusScale = bonus [index];
				blueTechnology.moduleNumber = modOrder [index];
				blueTechnology.upgradeType = types [index];
				blueTechnology.index = index;
				break;
			case 3:
			//Unlock Blue Skill Card Type
				blueTechnology.techName = "Upgrade Blue Skills Levels";
				blueTechnology.techDescription = "Increased All Blue Skill Level by 1";
				blueTechnology.cost = prices [index];
				blueTechnology.upgradeBonusScale = bonus [index];
				blueTechnology.moduleNumber = modOrder [index];
				blueTechnology.upgradeType = types [index];
				blueTechnology.index = index;
				break;
			case 4:
				blueTechnology.techName = "Tech Upgrade All Modules and Factory";
				blueTechnology.techDescription = "Increased All Blue Modules Damage by x" + bonus [index] + " and Automatically blue probe fabrication +1";
				blueTechnology.cost = prices [index];
				blueTechnology.upgradeBonusScale = bonus [index];
				blueTechnology.moduleNumber = modOrder [index];
				blueTechnology.upgradeType = types [index];
				blueTechnology.index = index;
				break;
			case 5:
				blueTechnology.techName = "Tech Upgrade " + blueModules [(modOrder [index] - 1)];
				blueTechnology.techDescription = "Reduce " + blueModules [(modOrder [index] - 1)] + " Cost to x" + bonus [index];
				blueTechnology.cost = prices [index];
				blueTechnology.upgradeBonusScale = bonus [index];
				blueTechnology.moduleNumber = modOrder [index];
				blueTechnology.upgradeType = types [index];
				blueTechnology.index = index;
				break;
			case 6:
			//Upgrade Blue Skill Card Type
				blueTechnology.techName = "Upgrade Blue Skills Levels";
				blueTechnology.techDescription = "Increased All Blue Skill Level by 1";
				blueTechnology.cost = prices [index];
				blueTechnology.upgradeBonusScale = bonus [index];
				blueTechnology.moduleNumber = modOrder [index];
				blueTechnology.upgradeType = types [index];
				blueTechnology.index = index;
				break;
			}

	}

	public void MakeRedTechCard (int type) {
		if (redTech == true) {
			for (int i = 0; i < numberOfRedTechDiscovery; i++) {
				resetCards = GameObject.Find ("Red Technology Card(Clone)");
				Destroy (resetCards);
			}
			//while (GameObject.Find ("Red Technology Card(Clone)")) {
			//	resetCards = GameObject.Find ("Red Technology Card(Clone)");
			//	Destroy (resetCards);
			//}
			redTech = false;
			numberOfRedCard = 0;
		}

			GameObject go;
			go = Instantiate (redTechCardPrefab) as GameObject;
			go.transform.SetParent (transform);
			redTechnology = (RedTechnologyManager)go.GetComponent (typeof(RedTechnologyManager));

			go.transform.SetParent (GameObject.Find ("TechContent").transform);
			RectTransform myRectTransform = go.transform.GetComponent<RectTransform> ();
			float myY = 160 + (310 * numberOfRedCard);
			myRectTransform.localPosition = new Vector3 (361.5f, -myY, 0.0f);
			numberOfRedCard++;

			switch (type) {
			case 0:
				redTechnology.techName = "Tech Upgrade " + redModules [(modOrder [index] - 1)];
				redTechnology.techDescription = "Increased " + redModules [(modOrder [index] - 1)] + " Damage by x" + bonus [index];
				redTechnology.mod = redModules [(modOrder [index] - 1)];
				redTechnology.cost = prices [index];
				redTechnology.upgradeBonusScale = bonus [index];
				redTechnology.moduleNumber = modOrder [index];
				redTechnology.upgradeType = types [index];
				redTechnology.index = index;
				break;
			case 1:
				redTechnology.techName = "Tech Upgrade Red Probe Factory";
				redTechnology.techDescription = "Automatically red probe fabrication +1";
				redTechnology.cost = prices [index];
				redTechnology.upgradeBonusScale = bonus [index];
				redTechnology.moduleNumber = modOrder [index];
				redTechnology.upgradeType = types [index];
				redTechnology.index = index;
				break;
			case 2:
				redTechnology.techName = "Tech Upgrade Red Probe Factory";
				redTechnology.techDescription = "Automatically red probe fabrication +1";
				redTechnology.cost = prices [index];
				redTechnology.upgradeBonusScale = bonus [index];
				redTechnology.moduleNumber = modOrder [index];
				redTechnology.upgradeType = types [index];
				redTechnology.index = index;
				break;
			case 3:
			//Unlock Red Skill Card Type
				redTechnology.techName = "Upgrade Red Skills Levels";
				redTechnology.techDescription = "Increased All Red Skill Level by 1";
				redTechnology.cost = prices [index];
				redTechnology.upgradeBonusScale = bonus [index];
				redTechnology.moduleNumber = modOrder [index];
				redTechnology.upgradeType = types [index];
				redTechnology.index = index;
				break;
			case 4:
				redTechnology.techName = "Tech Upgrade All Modules and Factory";
				redTechnology.techDescription = "Increased All Red Modules Damage by x" + bonus [index] + " and Automatically red probe fabrication +1";
				redTechnology.cost = prices [index];
				redTechnology.upgradeBonusScale = bonus [index];
				redTechnology.moduleNumber = modOrder [index];
				redTechnology.upgradeType = types [index];
				redTechnology.index = index;
				break;
			case 5:
				redTechnology.techName = "Tech Upgrade " + redModules [(modOrder [index] - 1)];
				redTechnology.techDescription = "Reduce " + redModules [(modOrder [index] - 1)] + " Cost to x" + bonus [index];
				redTechnology.cost = prices [index];
				redTechnology.upgradeBonusScale = bonus [index];
				redTechnology.moduleNumber = modOrder [index];
				redTechnology.upgradeType = types [index];
				redTechnology.index = index;
				break;
			case 6:
			//Upgrade Red Skill Card Type
				redTechnology.techName = "Upgrade Red Skills Levels";
				redTechnology.techDescription = "Increased All Red Skill Level by 1";
				redTechnology.cost = prices [index];
				redTechnology.upgradeBonusScale = bonus [index];
				redTechnology.moduleNumber = modOrder [index];
				redTechnology.upgradeType = types [index];
				redTechnology.index = index;
				break;
			}

	}

	public void MakeYellowTechCard (int type) {
		if (yellowTech == true) {
			for (int i = 0; i < numberOfYellowTechDiscovery; i++) {
				resetCards = GameObject.Find ("Yellow Technology Card(Clone)");
				Destroy (resetCards);
			}
			//while (GameObject.Find ("Yellow Technology Card(Clone)")) {
			//	resetCards = GameObject.Find ("Yellow Technology Card(Clone)");
			//	Destroy (resetCards);
			//}
			yellowTech = false;
			numberOfYellowCard = 0;
		}

			GameObject go;
			go = Instantiate (yellowTechCardPrefab) as GameObject;
			go.transform.SetParent (transform);
			yellowTechnology = (YellowTechnologyManager)go.GetComponent (typeof(YellowTechnologyManager));

			go.transform.SetParent (GameObject.Find ("TechContent").transform);
			RectTransform myRectTransform = go.transform.GetComponent<RectTransform> ();
			float myY = 160 + (310 * numberOfYellowCard);
			myRectTransform.localPosition = new Vector3 (361.5f, -myY, 0.0f);
			numberOfYellowCard++;

			switch (type) {
			case 0:
				yellowTechnology.techName = "Tech Upgrade " + yellowModules [(modOrder [index] - 1)];
				yellowTechnology.techDescription = "Increased " + yellowModules [(modOrder [index] - 1)] + " Parsec by x" + bonus [index];
				yellowTechnology.mod = yellowModules [(modOrder [index] - 1)];
				yellowTechnology.cost = prices [index];
				yellowTechnology.upgradeBonusScale = bonus [index];
				yellowTechnology.moduleNumber = modOrder [index];
				yellowTechnology.upgradeType = types [index];
				yellowTechnology.index = index;
				break;
			case 1:
				yellowTechnology.techName = "Tech Upgrade Yellow Probe Factory";
				yellowTechnology.techDescription = "Automatically yellow probe fabrication +1";
				yellowTechnology.cost = prices [index];
				yellowTechnology.upgradeBonusScale = bonus [index];
				yellowTechnology.moduleNumber = modOrder [index];
				yellowTechnology.upgradeType = types [index];
				yellowTechnology.index = index;
				break;
			case 2:
				yellowTechnology.techName = "Tech Upgrade Yellow Probe Factory";
				yellowTechnology.techDescription = "Automatically yellow probe fabrication +1";
				yellowTechnology.cost = prices [index];
				yellowTechnology.upgradeBonusScale = bonus [index];
				yellowTechnology.moduleNumber = modOrder [index];
				yellowTechnology.upgradeType = types [index];
				yellowTechnology.index = index;
				break;
			case 3:
			//Unlock Yellow Skill Card Type
				yellowTechnology.techName = "Upgrade Yellow Skills Levels";
				yellowTechnology.techDescription = "Increased All Yellow Skill Level by 1";
				yellowTechnology.cost = prices [index];
				yellowTechnology.upgradeBonusScale = bonus [index];
				yellowTechnology.moduleNumber = modOrder [index];
				yellowTechnology.upgradeType = types [index];
				yellowTechnology.index = index;
				break;
			case 4:
				yellowTechnology.techName = "Tech Upgrade All Modules and Factory";
				yellowTechnology.techDescription = "Increased All Yellow Modules Parsec by x" + bonus [index] + " and Automatically yellow probe fabrication +1";
				yellowTechnology.cost = prices [index];
				yellowTechnology.upgradeBonusScale = bonus [index];
				yellowTechnology.moduleNumber = modOrder [index];
				yellowTechnology.upgradeType = types [index];
				yellowTechnology.index = index;
				break;
			case 5:
				yellowTechnology.techName = "Tech Upgrade " + yellowModules [(modOrder [index] - 1)];
				yellowTechnology.techDescription = "Reduce " + yellowModules [(modOrder [index] - 1)] + " Cost to x" + bonus [index];
				yellowTechnology.cost = prices [index];
				yellowTechnology.upgradeBonusScale = bonus [index];
				yellowTechnology.moduleNumber = modOrder [index];
				yellowTechnology.upgradeType = types [index];
				yellowTechnology.index = index;
				break;
			case 6:
			//Upgrade Yellow Skill Card Type
				yellowTechnology.techName = "Upgrade Yellow Skills Levels";
				yellowTechnology.techDescription = "Increased All Yellow Skill Level by 1";
				yellowTechnology.cost = prices [index];
				yellowTechnology.upgradeBonusScale = bonus [index];
				yellowTechnology.moduleNumber = modOrder [index];
				yellowTechnology.upgradeType = types [index];
				yellowTechnology.index = index;
				break;
			}

	}

	public void SetRed () {
		isRed = true;
		isYellow = false;
		isGreen = false;
		isBlue = false;
	}

	public void SetYellow () {
		isRed = false;
		isYellow = true;
		isGreen = false;
		isBlue = false;
	}

	public void SetGreen () {
		isRed = false;
		isYellow = false;
		isGreen = true;
		isBlue = false;
	}

	public void SetBlue () {
		isRed = false;
		isYellow = false;
		isGreen = false;
		isBlue = true;
	}
	public void resetColor() {
		isRed = false;
		isYellow = false;
		isGreen = false;
		isBlue = false;
	}

	private SaveTechnology CreateSaveGameObject () {
		SaveTechnology newSave = new SaveTechnology ();
		newSave.numberOfGreenTechDiscovery = numberOfGreenTechDiscovery;
		newSave.numberOfBlueTechDiscovery = numberOfBlueTechDiscovery;
		newSave.numberOfRedTechDiscovery = numberOfRedTechDiscovery;
		newSave.numberOfYellowTechDiscovery = numberOfYellowTechDiscovery;

		newSave.BuyedGreenTech = BuyedGreenTech;
		newSave.BuyedBlueTech = BuyedBlueTech;
		newSave.BuyedRedTech = BuyedRedTech;
		newSave.BuyedYellowTech = BuyedYellowTech;

		return newSave;
	}

	public void SaveGame () {
		save = CreateSaveGameObject ();

		PlayerPrefs.SetString ("TechnologyManagerSave", Helper.Serialize<SaveTechnology> (save));
	}

	public void LoadGame () {
		if (PlayerPrefs.HasKey ("TechnologyManagerSave")) {
			save = Helper.DeSerialize<SaveTechnology>(PlayerPrefs.GetString("TechnologyManagerSave"));

			numberOfGreenTechDiscovery = save.numberOfGreenTechDiscovery;
			numberOfBlueTechDiscovery = save.numberOfBlueTechDiscovery;
			numberOfRedTechDiscovery = save.numberOfRedTechDiscovery;
			numberOfYellowTechDiscovery = save.numberOfYellowTechDiscovery;

			BuyedGreenTech = save.BuyedGreenTech;
			BuyedBlueTech = save.BuyedBlueTech;
			BuyedRedTech = save.BuyedRedTech;
			BuyedYellowTech = save.BuyedYellowTech;

		}
	}
}
