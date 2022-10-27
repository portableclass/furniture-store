let activePage;

document.getElementsByClassName('nav').onClick = (e) => {
	e.preventDefault()
	if (e.target.tagName === 'nav-link') {
		console.log(e.target)
		highlight(e.target)
	}
}

const highlight = (link) => {
	if (activePage)
		activePage.classList.remove('active')

	activePage = link
	activePage.classList.add('active')
}

