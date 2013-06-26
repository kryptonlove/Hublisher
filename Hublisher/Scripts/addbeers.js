$(function () {
	$("input[name=name]").autocomplete({
		delay: 100,
		source: function (request, response) {
			$.ajax({
				url: '/search/brands/' + request.term,
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
						var maker = item.maker || "";
						$("input[name=hidden_id]").val(item.id)

						return {
							label: item.name + ' (' + maker + ') ',
							value: item.name,
							description: item.description,
							country: item.country,
							type: item.type,
							volume: item.volume,
							maker: item.maker,
							brand_id: item.id
						}
					}));
				},
				error: function (request) {
					alert(request);
				}
			});
		},
		minLength: 2,
		select: function (event, ui) {
			$("input[name=maker]").val(ui.item.maker);
			$("textarea[name=description]").val(ui.item.description);
			$("input[name=country]").val(ui.item.country);
			$("input[name=type]").val(ui.item.type);
			$("input[name=volume]").val(ui.item.volume);
			$("input[name=brand_id]").val(ui.item.brand_id);

			$("#beer_exists").show();
		},
		open: function () {
			$(this).removeClass("ui-corner-all").addClass("ui-corner-top");
		},
		close: function () {
			$(this).removeClass("ui-corner-top").addClass("ui-corner-all");
		}
	});
});
