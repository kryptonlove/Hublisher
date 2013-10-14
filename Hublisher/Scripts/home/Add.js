function setDefaultCity() {
	var cityName = localStorage.getItem("defaultcity");

	$("input[name=searchcity]").val(cityName);
}

$(function () {
	setDefaultCity();

	$('input[name="searchcity"]').blur(function () {
		var cityName = $("input[name=searchcity]").val();

		localStorage.setItem("defaultcity", cityName);
	});


	$("#typeahead").autocomplete({
		delay: 100,

		source: function (request, response) {
			$.ajax({
				url: '/search/places/' + $("input[name=searchcity]").val() + '/' + request.term,
				dataType: "json",
				success: function (data) {
					if (data.length === 0) {
						$("input[name=hidden_id]").val("")
						return {
							label: '',
							value: ''
						}
					}

					response($.map(data, function (item) {
						var bor = item.borough || "";
						$("input[name=hidden_id]").val(item.id)

						return {
							label: item.name + bor,
							value: item.name
						}
					}));
				},
				error: function (request) {
					alert(request);
				}
			});
		},
		minLength: 2,
		open: function () {
			$(this).removeClass("ui-corner-all").addClass("ui-corner-top");
		},
		close: function () {
			$(this).removeClass("ui-corner-top").addClass("ui-corner-all");
		}
	});

	$("#cities").autocomplete({
		delay: 100,

		source: function (request, response) {
			$.ajax({
				url: '/search/cities/' + request.term,
				dataType: "json",
				success: function (data) {
					if (data.length === 0) {
						$("input[name=hidden_id]").val("")
						return {
							label: '',
							value: ''
						}
					}

					response($.map(data, function (item) {
						return {
							label: item,
							value: item
						}
					}));
				},
				error: function (request) {
					alert(request);
				}
			});
		},
		minLength: 2,
		open: function () {
			$(this).removeClass("ui-corner-all").addClass("ui-corner-top");
		},
		close: function () {
			$(this).removeClass("ui-corner-top").addClass("ui-corner-all");
		}
	});

});