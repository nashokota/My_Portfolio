// Main JS for beautiful portfolio interactions

document.addEventListener('DOMContentLoaded', function() {
    // 1. Project Card Hover Effect
    document.querySelectorAll('.project-card').forEach(card => {
        card.addEventListener('mouseenter', () => {
            card.style.boxShadow = '0 16px 40px rgba(39,41,109,0.22)';
            card.style.transform = 'scale(1.04)';
        });
        card.addEventListener('mouseleave', () => {
            card.style.boxShadow = '0 1px 8px rgba(39,41,109,0.08)';
            card.style.transform = 'scale(1)';
        });
    });

    // 2. Modal Popup for Project Details
    const modal = document.createElement('div');
    modal.id = 'project-modal';
    modal.style.position = 'fixed';
    modal.style.top = '0';
    modal.style.left = '0';
    modal.style.width = '100vw';
    modal.style.height = '100vh';
    modal.style.background = 'rgba(0,0,0,0.6)';
    modal.style.display = 'none';
    modal.style.justifyContent = 'center';
    modal.style.alignItems = 'center';
    modal.style.zIndex = '9999';
    modal.innerHTML = '<div id="modal-content" style="background:#fff;padding:2rem;border-radius:1rem;max-width:400px;box-shadow:0 2px 16px #0003;position:relative;"></div>';
    document.body.appendChild(modal);

    function showModal(title, desc, links) {
        const content = document.getElementById('modal-content');
        content.innerHTML = `<h2 style=\"margin-bottom:1rem;\">${title}</h2><p style=\"margin-bottom:1rem;\">${desc}</p><div>${links}</div><button id=\"close-modal\" style=\"position:absolute;top:1rem;right:1rem;font-size:1.5rem;cursor:pointer;\">&times;</button>`;
        modal.style.display = 'flex';
        document.getElementById('close-modal').onclick = () => { modal.style.display = 'none'; };
    }

    document.querySelectorAll('.project-card').forEach(card => {
        card.style.cursor = 'pointer';
        card.addEventListener('click', function() {
            const title = card.querySelector('.project-title').textContent;
            const desc = card.querySelector('.project-desc').textContent;
            const links = card.querySelector('.project-links') ? card.querySelector('.project-links').innerHTML : '';
            showModal(title, desc, links);
        });
    });

    // 3. Smooth Scroll for Navbar Links
    document.querySelectorAll('.navbar a[href^="#"]').forEach(link => {
        link.addEventListener('click', function(e) {
            const target = document.querySelector(this.getAttribute('href'));
            if (target) {
                e.preventDefault();
                target.scrollIntoView({ behavior: 'smooth' });
            }
        });
    });

    // 4. Button Ripple Effect
    document.querySelectorAll('.btn').forEach(btn => {
        btn.addEventListener('click', function(e) {
            const ripple = document.createElement('span');
            ripple.className = 'ripple';
            ripple.style.left = e.offsetX + 'px';
            ripple.style.top = e.offsetY + 'px';
            this.appendChild(ripple);
            setTimeout(() => ripple.remove(), 600);
        });
    });

    // 5. Animate Skill Bars on Scroll
    function animateSkills() {
        document.querySelectorAll('.skill-bar span').forEach(bar => {
            const width = bar.getAttribute('style').match(/width:\s*([0-9]+%)/);
            if (width) {
                bar.style.width = '0';
                setTimeout(() => {
                    bar.style.width = width[1];
                }, 300);
            }
        });
    }
    let skillsAnimated = false;
    window.addEventListener('scroll', function() {
        const skillsSection = document.querySelector('.skills-block');
        if (skillsSection && !skillsAnimated) {
            const rect = skillsSection.getBoundingClientRect();
            if (rect.top < window.innerHeight - 100) {
                animateSkills();
                skillsAnimated = true;
            }
        }
    });
    // Animate on load if already in view
    animateSkills();
});

// Ripple effect CSS (inject)
const rippleStyle = document.createElement('style');
rippleStyle.textContent = `
.ripple {
    position: absolute;
    border-radius: 50%;
    background: rgba(94,162,235,0.3);
    transform: scale(0);
    animation: ripple 0.6s linear;
    pointer-events: none;
    width: 60px;
    height: 60px;
    left: 50%;
    top: 50%;
    margin-left: -30px;
    margin-top: -30px;
    z-index: 1;
}
@keyframes ripple {
    to {
        transform: scale(2.5);
        opacity: 0;
    }
}
`;
document.head.appendChild(rippleStyle);
