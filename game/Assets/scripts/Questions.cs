using UnityEngine;
using System.Collections;

public class Questions : MonoBehaviour {

	// Create a 2D string array for questions and answers
	public static string[,] qa = new string[,] {
		{
			"", // leaving first one empty so the counter starts at 1
			"",	// instead of zero
			"",
			"",
			"",
			"",
			"",
		},

		{
			"All tumors are cancerous.",
			"True",
			"False",
			"",
			"",
			"2",
			"some tumors are not cancerous. \nThose tumors are called benign tumors, which do not \nspread to other parts of the body",
		},

		{
			"Which of the following defines cancer:",
			"Autoimmune disease",
			"Genetic condition",
			"Abnormal cell growth",
			"None of the above defines cancer",
			"3",
			"",
		},

		{
			"Which of the following are possible cancer symptoms:",
			"Lumps",
			"Abnormal bleeding",
			"Weight loss",
			"All may be associated symptoms with cancer",
			"4",
			"",
		},

		{
			"Over 250 types of cancers affect humans.",
			"True",
			"False",
			"",
			"",
			"2",
			"only a 100 types of cancer are known to affect humans",
		},

		{
			"Which of the following contributes to cancer:",
			"Tobacco",
			"Obesity",
			"Lack of physical activity",
			"All of the above may contribute to the development of cancer",
			"4",
			"",
		},

		{
			"Tobacco use cause about 15% of cancer deaths",
			"True",
			"False",
			"",
			"",
			"2",
			"tobacco use cause about 22% of cancer deaths",
		},

		{
			"Cancer is genetic and cannot be prevented",
			"True",
			"False",
			"",
			"",
			"2",
			"",
		},

		{
			"Abnormal cell growth does not always invade or \nspread to other parts of the body.",
			"True",
			"False",
			"",
			"",
			"1",
			"",
		},

		{
			"Which of the following is a characteristic of \nmalignant tumor",
			"Cell death programing",
			"Blood vessels dilation",
			"Avoidance of programmed cell death",
			"",
			"3",
			"",
		},

		{
			"What is the main cause of cancer development",
			"Inherited genetics",
			"Environmental factors",
			"It is not possible to prove what causes a specific cancer",
			"Both 2nd and 3rd choices are correct",
			"4",
			"environmental factors such as pollution, \ntobacco, diet and opposite and infections are \nconsidered to contribute around 90-95% of cancer cases",
		},

		{
			"Another word for cancer is:",
			"Tumor",
			"Malignant",
			"Benign",
			"Non of the above",
			"2",
			"",
		},

		{
			"Which of the following cancers is \nNOT a common cancer in Men:",
			"Thyroid gland",
			"Bladder",
			"Prostate",
			"Colon and rectum",
			"1",
			"",
		},

		{
			"Which of the following is the first \nstep in cancer development:",
			"Promotion",
			"Spread",
			"Initiation",
			"Non of the above",
			"3",
			"",
		},

		{
			"Factors that promotes the development \nof cancer are called Carcinogens",
			"True",
			"False",
			"",
			"",
			"1",
			"",
		},

		{
			"Stage 4 cancer refers to a cancer that hasn’t \nspread that much",
			"True",
			"False",
			"",
			"",
			"2",
			"stage 4 cancer is considered the highest \nstage in which the cancer has spread into \nmany areas",

		},

		{
			"Which of the following are possible treatments \nfor cancer:",
			"Surgery",
			"Chemotherapy",
			"Radiation",
			"All of the above",
			"4",
			"",
		},

		{
			"How many cases of new cancers are diagnosed \neach year",
			"Million",
			"2 million",
			"100,000",
			"Half a million",
			"4",
			"",
		},

		{
			"Only 5%-10% of cancers are linked to inherited genes",
			"True",
			"False",
			"",
			"",
			"1",
			"",
		},

		{
			"Which type of cancer kills the most women each year?",
			"Breast cancer",
			"Lung cancer",
			"Ovarian cancer",
			"",
			"2",
			"although breast cancer is more common among women, \nlung cancer kills more women. Smoking is the primary \nrisk factor for lung cancer",
		},

		{
			"Which type of cancer kills the most men each year?",
			"Prostate cancer",
			"Lung cancer",
			"Colon cancer",
			"",
			"2",
			"although prostate cancer is much more common in men, \nlung cancer is still the deadliest cancer due to cigarette \nsmoking",
		},

		{
			"Carcinoma is:",
			"Cancer that arise from connective tissue",
			"Cancer that is found in the lymph nodes or blood",
			"Cancer that is derived from epithelial cells",
			"Cancers that are found in the testicle of ovary",
			"3",
			"",
		},

		{
			"Sarcoma is a type of cancer that arises from \nconnective tissue",
			"True",
			"False",
			"",
			"",
			"1",
			"",
		},

		{
			"Blastoma refers to cancer cells that are found in \nthe lympth nodes and blood",
			"True",
			"False",
			"",
			"",
			"2",
			"Lymphoma and leukemia are cancers that are connected \nto the lymph nodes and blood. Blastoma is a classication of cancer \nderived in embryonic tissue",
		},

		{
			"Which of the follwoing classification refers to cancers \nderived from pluripotent cells in the testicle or ovary?",
			"Carcinoma",
			"Sarcoma",
			"Blastoma",
			"Germ cell tumor",
			"4",
			"",
		},

		{
			"Oncogenes are genes that inhibit cell growth and \nsurvival",
			"True",
			"False",
			"",
			"",
			"2",
			"Oncogenese are genes that promotes cell growth",
		},

		{
			"In order for a normal cell to transform into a cancer \ncell changes in multiple genes are required",
			"True",
			"False",
			"",
			"",
			"1",
			"",
		},

		{
			"Tumors can be classified as:",
			"Benign",
			"Malignant",
			"Both 1st and 2nd choices are tumor classification",
			"Non of the above",
			"3",
			"",
		},

		{
			"Which of the following is NOT a genetic influence \nassociated with cancer?",
			"Mutations",
			"Oncogenes",
			"Tumor-Suppressor genes",
			"Mitosis progression",
			"4",
			"",
		},

		{
			"Carcinogen is another word for:",
			"Another name for cancer",
			"Cancer causing substance",
			"A gene",
			"A type of blood disease",
			"2",
			"",
		},

		{
			"Cancer is contagious",
			"True",
			"False ",
			"",
			"",
			"2",
			"",
		},

		{
			"Aside from not smoking which of the following can \nbe a major cause of cancer?",
			"Artificial sweeteners",
			"Cell phones",
			"Obesity",
			"Genetically modified foods",
			"3",
			"",
		},

		{
			"Physical activity lowers cancer risk",
			"True",
			"False ",
			"",
			"",
			"1",
			"",
		},

		{
			"Surgery, Chemotherapy and radiotherapy are all \nways of?",
			"Treating cancer",
			"Finding cancer",
			"Causing cancer",
			"Both 1st and 2nd choices are correct",
			"1",
			"",
		}
						
	};

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		

}
