var ReportGenerationTest = {
	NormalizedDictionary: function () {
		var dict = this;
		this.put = function (key, value) {
			dict[key] = value;
		};
	}
};

var printObject = function (object) {
	var str = "";
	for (var key in object) {
		try {
			str += " -------------------- " + key + " : " + object[key];
		} catch (e) {
			str += " -------------------- " + key + " : error reading - " + printObject(e);
		}
	}
	return str;
};

var generateReport = function (model, view) {

	var newModel = new ReportGenerationTest.NormalizedDictionary();

//	var newModel = model.GetNewViewModel();
//	newModel.put("Name", model.get_Name());
//	newModel.put("ProductCount", model.get_Products().get_Count());
	
	newModel.put("Name", model.get_Name());
	//newModel.put("ProductCount", model.get_Products()._length);
	newModel.put("ProductCount", 5);
	// newModel.put("Products", model.get_Products()); // this is a List<Product> and does not work well
	view.put("Customer", newModel);
	
	var products = model.GetProducts();
	var count = 0;
	for (var product in  products) {
		count += product;
	}
	newModel.put("ProductCount", products.length);
	

	var slicedProducts = [products[1]];
	newModel.put("Products", slicedProducts);
	

	view.put("Debug", printObject(model.GetProducts()));
};