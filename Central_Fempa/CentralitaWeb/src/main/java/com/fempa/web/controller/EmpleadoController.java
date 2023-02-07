package com.fempa.web.controller;

import com.fempa.web.model.Empleado;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PostMapping;

@Controller
public class EmpleadoController {

    @GetMapping("/empleado")
    public String empleadoForm(Model model) {
        model.addAttribute("empleado", new Empleado());
        return "empleado";
    }

    @PostMapping("/empleado")
    public String empleadoSubmit(@ModelAttribute Empleado empleado, Model model) {
        model.addAttribute("empleado", new Empleado());
        return "result";
    }
}


