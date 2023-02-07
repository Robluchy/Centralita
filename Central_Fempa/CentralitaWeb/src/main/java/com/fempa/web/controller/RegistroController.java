package com.fempa.web.controller;

import com.fempa.web.model.Registro;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;

@Controller
public class RegistroController {
    @GetMapping("/registro")
    public String registroForm(Model model) {
        model.addAttribute("registro", new Registro());
        return "registro";
    }

    @PostMapping("/registro")
    public String registroSubmit(@ModelAttribute Registro registro, Model model) {
        model.addAttribute("registro", new Registro());
        return "result";
    }
}
